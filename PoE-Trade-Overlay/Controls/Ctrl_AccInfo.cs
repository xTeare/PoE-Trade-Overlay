using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace PoE_Trade_Overlay.Controls
{
    public partial class Ctrl_AccInfo : UserControl
    {
        private HttpWebRequest getRequest;
        private HttpWebRequest voteRequest;

        private string scamVotes;
        private bool canVote = true;

        public Ctrl_AccInfo()
        {
            InitializeComponent();
        }

        private string LoadPriceInChaos(string origPrice, float amount)
        {
            string priceString = Data.GetChaosEquivalent(origPrice);
            try
            {
                float price = float.Parse(priceString);
                return (price * amount).ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("Ctrl_AccInfo::LoadPriceInChaos exception : {0}, Input String {1}", e.Message, origPrice));
            }

            return "";
        }

        public void QueryData(Queries.Result result)
        {
            ServicePointManager.Expect100Continue = false;
            ServicePointManager.DefaultConnectionLimit = 50;
            HttpWebRequest.DefaultWebProxy = null;
            ServicePointManager.CheckCertificateRevocationList = false;

            try
            {
                getRequest = (HttpWebRequest)WebRequest.Create("http://poeto.net/api/check.php?voted=" + result.Listing.Account.Name);
                voteRequest = (HttpWebRequest)WebRequest.Create("http://poeto.net/api/vote.php?voter=" + Config.GetID() + "&voted=" + result.Listing.Account.Name);
            }
            catch
            {
                btn_ScamVote.Text = "Error";
                lbl_scamVotes.Text = "Error";
            }

            getRequest.BeginGetResponse(new AsyncCallback(FinishWebRequest), null);

            lbl_accName.Text = "Acc.: " + result.Listing.Account.Name;
            lbl_lastChar.Text = "IGN: " + result.Listing.Account.LastCharacterName;
            lbl_lastChar.Location = new Point(this.Width - lbl_lastChar.Width, 4);

            if (result.Listing.Price != null)
            {
                lbl_priceAmount.Text = result.Listing.Price.Amount.ToString() + " x";
                lbl_priceAmount.Location = new Point(pb_currencyIcon.Location.X - lbl_priceAmount.Width, 48);
                lbl_priceType.Location = new Point(lbl_priceAmount.Left - lbl_priceType.Width, 48);
                pb_currencyIcon.Image = Data.GetCurrencyImage(result.Listing.Price.Currency);
            }

            if (Ninja.isEnabled && Config.GetEntryB("Enable Price in Chaos conversion") && result.Listing.Price.Currency != "chaos")
            {
                string currencyName = result.Listing.Price.Currency.GetFullCurrencyName();
                lbl_priceInChaos.Text = "Price in Chaos : " + LoadPriceInChaos(currencyName, (float)result.Listing.Price.Amount);
                lbl_priceInChaos.Location = new Point(this.Width - lbl_priceInChaos.Width - 3, lbl_priceInChaos.Top);
            }
            else
            {
                lbl_priceInChaos.Visible = false;
            }

            // If ...Online is null the seller is offline
            if (result.Listing.Account.Online == null)
            {
                lbl_status.Text = "offline";
                lbl_status.BackColor = Constants.Offline;
            }
            else
            {
                // if online != null but status is, the seller is online
                if (result.Listing.Account.Online.Status == null)
                {
                    lbl_status.Text = "online";
                    lbl_status.BackColor = Constants.Online;
                }
                else
                {
                    lbl_status.Text = "afk";
                    lbl_status.BackColor = Constants.Afk;
                }
            }
        }

        private void Btn_ScamVote_Click(object sender, EventArgs e)
        {
            if (canVote)
                voteRequest.BeginGetResponse(new AsyncCallback(VoteFinished), null);
        }

        #region ScamVotes

        private void FinishWebRequest(IAsyncResult result)
        {
            try
            {
                HttpWebResponse response = (HttpWebResponse)getRequest.EndGetResponse(result);

                if (response != null)
                {
                    using (var streamReader = new StreamReader(response.GetResponseStream()))
                    {
                        scamVotes = streamReader.ReadToEnd();

                        if (lbl_scamVotes.InvokeRequired)
                            lbl_scamVotes.Invoke(new MethodInvoker(delegate { lbl_scamVotes.Text = "Scam Votes " + scamVotes; }));
                        else
                            lbl_scamVotes.Text = "Scam Votes : " + scamVotes;
                    }
                }
            }
            catch
            {
                if (btn_ScamVote.InvokeRequired)
                    btn_ScamVote.Invoke(new MethodInvoker(delegate { btn_ScamVote.Text = "Error"; }));
                else
                    btn_ScamVote.Text = "Error";
                if (lbl_scamVotes.InvokeRequired)
                    lbl_scamVotes.Invoke(new MethodInvoker(delegate { lbl_scamVotes.Text = "Error"; }));
                else
                    lbl_scamVotes.Text = "Error";

                canVote = false;
            }
        }

        private void VoteFinished(IAsyncResult result)
        {
            try
            {
                HttpWebResponse response = (HttpWebResponse)voteRequest.EndGetResponse(result);

                if (response != null)
                {
                    using (var streamReader = new StreamReader(response.GetResponseStream()))
                    {
                        string c = streamReader.ReadToEnd();
                        Console.WriteLine(c);
                        switch (c)
                        {
                            case "-1":
                                SetVoteBtnText("Error");
                                break;

                            case "0":
                                SetVoteBtnText("Already Voted");
                                break;

                            case "1":
                                SetVoteBtnText("Voted");
                                break;
                        }
                    }
                }
                else
                {
                    SetVoteBtnText("Error");
                }
            }
            catch
            {
                SetVoteBtnText("Error");
            }
        }

        private void SetVoteBtnText(string text)
        {
            if (btn_ScamVote.InvokeRequired)
            {
                btn_ScamVote.Invoke(new MethodInvoker(delegate { btn_ScamVote.Text = text; }));
            }
            else
            {
                btn_ScamVote.Text = text;
            }
            // Remove click event
            btn_ScamVote.Click -= Btn_ScamVote_Click;
        }

        #endregion ScamVotes
    }
}