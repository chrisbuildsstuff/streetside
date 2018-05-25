using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Telesign;
using System.Timers;

namespace Streetside
{
    public partial class _Default : Page
    {
        public string currentTime;
        public string customerId;
        public string apiKey;
        public string phoneNumber;
        public string message;
        public string messageType;
        public bool canSendText;
        public string dayOfWeek;
        public string hour;
        public string minute;
        public string second;       

        protected void Page_Load(object sender, EventArgs e)
        {
            canSendText = true;
            customerId = "F8157E35-E492-4714-A593-FA95C9EED242";
            apiKey = "IX9W5JQYQNDRoBFBlGoJwwO6XmZY4zgJQz/szIV+r8boqhNP0OoZ+UkpuLQAWW6OOrPOAQtcH8X9UGQl7KRPqA==";
            phoneNumber = "13153955198";
            message = "TEST";
            messageType = "ARN";

            System.Timers.Timer aTimer = new System.Timers.Timer(1000);

            aTimer.Elapsed += Timer1_Tick;
            aTimer.Enabled = true;
            aTimer.Start();


        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            DateTime current = DateTime.Now;
            dayOfWeek = current.DayOfWeek.ToString();
            hour = current.Hour.ToString();
            minute = current.Minute.ToString();
            second = current.Second.ToString();

            now.InnerText = dayOfWeek + " " + hour + ":" + minute + ":" + second;

            try
            {
                if (dayOfWeek.ToLower() == "thursday")
                {
                    if (hour == "15" && minute == "30") {
                        if (canSendText)
                        {
                            MessagingClient messagingClient = new MessagingClient(customerId, apiKey);
                            RestClient.TelesignResponse telesignResponse = messagingClient.Message(phoneNumber, message, messageType);

                            canSendText = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}