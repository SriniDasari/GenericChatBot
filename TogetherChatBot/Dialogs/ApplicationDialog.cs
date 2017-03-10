using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace TogetherChatBot
{
    [Serializable]
    public class ApplicationDialog : IDialog<object>
    {
       
        public async Task StartAsync(IDialogContext context)
        {
             context.Wait(MessageReceivedAsync);
        }
        public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            //var message = await argument;
            //await context.PostAsync("You said: " + message.Text);
            //context.Wait(MessageReceivedAsync);

            var message = await argument;
            if (message.Text.ToLower().Contains("apply"))
            {
                await context.PostAsync("That’s simple. Please provide me with your name, email address and phone number. Our customer service representative will get in touch with you shortly.");
                context.Wait(MessageReceivedAsync);
            }
            else if (message.Text.ToLower().Contains("name") || message.Text.ToLower().Contains("email") || message.Text.ToLower().Contains("phone") || message.Text.ToLower().Contains("number"))
            {
               
            }

        }

        //public async Task AfterResetAsync(IDialogContext context, IAwaitable<bool> argument)
        //{
        //    var confirm = await argument;
        //    if (confirm)
        //    {
        //        this.count = 1;
        //        await context.PostAsync("Reset count.");
        //    }
        //    else
        //    {
        //        await context.PostAsync("Did not reset count.");
        //    }
        //    context.Wait(MessageReceivedAsync);
        //}
    }
}