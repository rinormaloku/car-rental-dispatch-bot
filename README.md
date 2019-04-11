Prerequisite: 
```
npm i -g msbot luis-apis qnamaker ludown botdispatch
```

1. Create the luis and qna cognetive models
```
ludown parse toluis --in Resources/car-rental.lu -o CognitiveModels --out car-rental.luis -n "Car Rental" -d "Car Rental Luis App" --verbose
ludown parse toqna --in resources/car-qna.lu -o CognitiveModels --out car-bot.qna -n "Car QnA" --verbose
```

2. Create the Service LUIS and QnA [many minutes later]

3. Import the data into the services
```
luis import application --in CognitiveModels/car-rental.luis --authoringKey <AuthKey> --region <Region> 
qnamaker create kb --in cognitiveModels/car-bot.qna --subscriptionKey <NotSubKey> --wait
```

! Subscription key is the key of the created QnA Service.

4. Add the information to the bot.

```
msbot connect luis --name CarRental --appId <AppId> --version 0.1 --authoringKey <AuthKey> -b CarRentalDispatchBot.bot
msbot connect qna --name CarQnA --kbId <KbID> --subscriptionKey <NotSubKey> --endpointKey <EndpointKey> --hostname <Host> -b CarRentalDispatchBot.bot
```

5. Create the dispatch luis app
```
dispatch create -b CarRentalDispatchBot.bot
msbot connect dispatch --name CarRentalDispatch --appId <AppId> --version 0.1 --authoringKey <AuthKey> -b CarRentalDispatchBot.bot
```

6. Add Regions for Luis apps in the .Bot file.

7. Run the app.