using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsOffice.Client.Models
{
    public enum ErrorCode
    {
        /// <summary>
        /// მესიჯი მიღებულია smsoffice -ს მიერ სამომავლოდ ნომერთან გადასაგზავნად. ეს ჯერ არ ნიშნავს, რომ მესიჯი მივიდა მობილურ ტელეფონში. მესიჯის მისვლას შეიტყობთ მიღების უწყისში
        /// </summary>
        Success = 0,
        /// <summary>
        /// destination შეიცავს არაქართულ ნომრებს
        /// </summary>
        NotGeorgianNumbers = 10,
        /// <summary>
        /// ბალანსი არასაკმარისია
        /// </summary>
        InsufficientBalance = 20,
        /// <summary>
        /// გასაგზავნი ტექსტი 160 სიმბოლოზე მეტია
        /// </summary>
        TextMoreThan160Symbols = 40,
        /// <summary>
        /// ბრძანებას აკლია content პარამეტრის მნიშვნელობა, გასაგზავნი ტექსტი
        /// </summary>
        ContentParameterMissing = 60,
        /// <summary>
        /// ბრძანებას აკლია ნომრები
        /// </summary>
        MissingNumbers = 70,
        /// <summary>
        /// ყველა ნომერი სტოპ სიაშია
        /// </summary>
        AllNumbersInStopList = 75,
        /// <summary>
        /// ყველა ნომერი არასწორი ფორმატითაა მოწოდებული
        /// </summary>
        AllNumbersInvalidFormat = 76,
        /// <summary>
        /// ყველა ნომერი სტოპ სიაშია ან არასწორი ფორმატითაა მოწოდებული
        /// </summary>
        AllNumbersInStopListOrInvalidFormat = 77,
        /// <summary>
        /// key -ს შესაბამისი მომხმარებელი ვერ მოიძებნა
        /// </summary>
        CustomerNotFoundByKey = 80,
        /// <summary>
        /// sender პარამეტრის მნიშვნელობა გაუგებარია
        /// </summary>
        InvalidSenderParameter = 110,
        /// <summary>
        /// გააქტიურეთ api -ის გამოყენების უფლება პროფილის გვერდზე
        /// </summary>
        ActivateApiInprofile = 120,
        /// <summary>
        /// sender არ იძებნება სისტემაში. შეამოწმეთ მართლწერა
        /// </summary>
        InvalidSender = 150,
        /// <summary>
        /// ბრძანებას აკლია key პარამეტრი
        /// </summary>
        MissingKeyParameter = 500,
        /// <summary>
        /// ბრძანებას აკლია destination პარამეტრი
        /// </summary>
        MissignDestinationParameter = 600,
        /// <summary>
        /// ბრძანებას აკლია sender პარამეტრი
        /// </summary>
        MissingSenderParameter = 700,
        /// <summary>
        /// ბრძანებას აკლია content პარამეტრი
        /// </summary>
        MissignContentParameter = 800,
        /// <summary>
        /// დროებითი შეფერხება
        /// </summary>
        TemporaryDelay = -100
    }
}
