using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using TogetherChatBot.Models;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;


namespace TogetherChatBot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            string[] strArray = { "1", "2", "3", "4", "5" };
            if (activity.Type == ActivityTypes.Message)
            {
                ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                
                if ((activity.Text.ToLower().Equals("hi")) || activity.Text.ToLower().Equals("hello"))
                {
                    Activity reply = activity.CreateReply("Hello there! How can I help you today?");
                    await connector.Conversations.ReplyToActivityAsync(reply);
                }
                else if (activity.Text.ToLower().Contains("ensure") || activity.Text.ToLower().Contains("ok"))
                {
                    Activity reply = activity.CreateReply("Noted! Is there anything else I can help you with?");
                    await connector.Conversations.ReplyToActivityAsync(reply);
                }
                else if ((activity.Text.ToLower().Contains("no")) || (activity.Text.ToLower().Contains("thanks")) || (activity.Text.ToLower().Contains("nothing")))
                {
                    Activity reply = activity.CreateReply("Ok. Have a good day!");
                    await connector.Conversations.ReplyToActivityAsync(reply);
                }

                //else if (activity.Text.ToLower().Contains("apply") || activity.Text.ToLower().Contains("email") || activity.Text.ToLower().Contains("phone") || activity.Text.ToLower().Contains("number") || activity.Text.ToLower().Contains("call") || activity.Text.ToLower().Contains("name"))
                //{
                //    // await Conversation.SendAsync(activity, () => new ApplicationDialog());
                //    await Conversation.SendAsync(activity, MakeAccountDialog);
                //}
                else //if (activity.Text.ToLower().Contains("loan") || activity.Text.ToLower().Contains("mortgage") || activity.Text.ToLower().Contains("bridging") || strArray.Any(activity.Text.Equals))
                {
                    await Conversation.SendAsync(activity, MakeLoanDialog);
                }

            }
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return null;
        }


        //internal static IDialog<Account> MakeRootDialog()
        //{
        //    return Chain.From(() => FormDialog.FromForm(Account.BuildForm));

        //}

        internal static IDialog<Loans> MakeLoanDialog()
        {
            return Chain.From(() => FormDialog.FromForm(Loans.BuildForm));
        }

        //internal static IDialog<Account> MakeAccountDialog()
        //{
        //    return Chain.From(() => FormDialog.FromForm(Account.BuildForm));
        //}

    }
}