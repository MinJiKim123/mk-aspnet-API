# mk-aspnet-API

## About this project
* Simple Web API that manages financial expenses
* This API is consumed in here
* This API is not available for public use at the moment. 

### Data (AWS DynamoDB)
![image](https://user-images.githubusercontent.com/61156520/102808708-c1286880-438e-11eb-8f60-cd2f5658375b.png)

### API
* GET /api
* POST /api
* GET /api/{expId}
* DELETE /api/{expId}
* PUT /api/{expId}

### Publish API
* Elastic Beanstalk

![image](https://user-images.githubusercontent.com/61156520/102808749-d00f1b00-438e-11eb-969a-7f1bf086c9d1.png)

* Create API Proxy

![image](https://user-images.githubusercontent.com/61156520/102808803-e917cc00-438e-11eb-9780-9a8753d016e8.png)

* Consume API (Refer to APIClient project code)

![image](https://user-images.githubusercontent.com/61156520/102808867-08aef480-438f-11eb-8590-9c56852450a2.png)

### Technology Used
* ASP.NET
* AutoMapper
* Repository Pattern
* MVC Pattern

