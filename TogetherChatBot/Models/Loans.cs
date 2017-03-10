using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TogetherChatBot.Models
{

    public enum LoanOptions
    {
        PersonalBridgingLoan,
        CommercialBridgingLoan,
        PersonalMortgages,
        CommercialMortgages
    };

    public enum LoanTypeOptions
    {
        StandardBridgingLoan,
        ChainBreakBridging,
        CapitalReleaseBridging
    };

    public enum ApplyConfirm
    {
        Yes,
        No
    }

    public enum Confirm
    {
        Yes,
        No
    }

    [Serializable]
    public class Loans
    {
        [Prompt("What kind of {&} you are looking for? Please click any one of these.  {||}")]
        public LoanOptions? Loan;

        [Prompt("Please select one of the below {&} options to know more. {||}")]
        public LoanTypeOptions? LoanType;

        [Prompt("Would you like to apply? {||}")]
        public ApplyConfirm? ApplyConfirm;

        [Prompt("Please enter your name")]
        public string Name;

        [Prompt("Please enter your contact number")]
        public string PhoneNumber;

        [Prompt("Please enter your email address.")]
        public string EmailAddress;

        [Prompt("Please confirm? {||}")]
        public Confirm? Confirm;
        public static IForm<Loans> BuildForm()
        {
         
            return new FormBuilder<Loans>()
                    //.Message("What type of loan do you require?")
                    .Field(nameof(Loans.Loan))
                    .Field(nameof(Loans.LoanType))
                    .Confirm("{LoanType} Details: We offer loans up to 1 million pounds in this category. LTV can be up to 70 %. Rates from 0.65 % a month up to 50 % LTV. Rates from 0.75 % a month up to 70 % LTV. Available for 12 months. Our standard personal bridging loan can be secured against a single property as a first charge. Would you like to apply? Please confirm by Yes/No.")
                    //.Field(nameof(Loans.ApplyConfirm))
                    .Field(nameof(Loans.Name))
                    .Field(nameof(Loans.PhoneNumber))
                    .Field(nameof(Loans.EmailAddress))
                    .Confirm("Thanks for the information. Please confirm the following: Your Full Name: {Name}, Phone Number : {PhoneNumber}, Email Address: {EmailAddress}. Please confirm by Yes/No. ")
                    //.Field(nameof(Loans.Confirm))
                    .Message("Thanks for the confirmation {Name}. Your reference number is 128723612Aadf. Do expect a call within the next 48 hours.")
                     //.OnCompletion(async (context, e) =>
                     //{
                     //    await context.PostAsync("Thanks for the report!");
                     //})
                    .Build();
        }

    }
}