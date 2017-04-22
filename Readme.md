# Gateway Service

## Taks

- Create service that talks to **ScoringService** and **MatchingService**

Verb : `POST`
Endpoint : `/loans`
Request Body :
```json
{
    "name" : "jan",
    "lastName" : "kowalski",
    "country" : "Poland",
    "income" : 100000,
    "mortgage" : false,
    "amount" : 1000
}
```

- If `ScoringService` returns `Eligblity: false` then return `404 with message That loan cant be quoted for given information`

- If `ScoringService` returns `Eligblity: true` then return object with quote result 
```json
{
    "amountRequested" : 1000,
    "totalAmounttoRepay" :  1008,
    "apr" : 7.9%,
    "montlyRepayments" : 68.95
}
```