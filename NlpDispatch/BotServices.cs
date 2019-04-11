using System;
using System.Collections.Generic;
using Microsoft.Bot.Builder.AI.Luis;
using Microsoft.Bot.Builder.AI.QnA;

namespace CarRentalDispatchBot.NlpDispatch
{
    // Wrapper of external services
    public class BotServices
    {
        public BotServices(Dictionary<string, QnAMaker> qnaServices, Dictionary<string, LuisRecognizer> luisServices)
        {
            QnAServices = qnaServices ?? throw new ArgumentNullException(nameof(qnaServices));
            LuisServices = luisServices ?? throw new ArgumentNullException(nameof(luisServices));
        }

        public Dictionary<string, QnAMaker> QnAServices { get; } = new Dictionary<string, QnAMaker>();

        public Dictionary<string, LuisRecognizer> LuisServices { get; } = new Dictionary<string, LuisRecognizer>();
    }
}
