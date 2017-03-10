using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TogetherChatBot.Models
{

    public enum LeaveOptions
    {
        SickLeave,
        //[Terms(new string[] { "cas", "casl" })]
        CasualLeave, EarnedLeave
    };
    public enum DaysOptions { HalfDay, FullDay };

    public enum SlotOptions
    {
        Morning = 1,
        Evening
    };

    [Serializable]
    public class Account
    {
        ////[Prompt("Select Nature of Leave")]
        //public LeaveOptions? Leave;
        ////[Template(TemplateUsage.EnumSelectOne, "Please give the")]
        //public DaysOptions? Day;

        //public SlotOptions Slot;

        [Prompt("Please enter your name")]
        public string Name;

        [Prompt("Please enter your contact number")]
        public string PhoneNumber;

        [Prompt("Please enter your email address.")]
        public string EmailAddress;

        //public Confirm? Day;
        //[Prompt("Please Enter Leave Start Date")]
        //public DateTime? fromDate;
        //[Prompt("Please Enter Leave End Date")]
        //public DateTime? toDate;


        public static IForm<Account> BuildForm()
        {
            return new FormBuilder<Account>()
                    //.Message("Hello there! How can I help you?")
                    .Field(nameof(Account.Name))
                    .Field(nameof(Account.PhoneNumber))
                    .Field(nameof(Account.EmailAddress))

                    //.Field(nameof(Account.fromDate))
                    //.Field(nameof(Account.toDate))
                     .Confirm("Thanks for the information. Please confirm the following: Your Full Name: {Name}, Phone Number : {PhoneNumber}, Email Address: {EmailAddress} ")
                     //.Confirm("Do you want to apply {Leave} with {Day} & Reason {LeaveReason} from duration {fromDate} to {toDate}")
                    .Build();


        }
    }
}