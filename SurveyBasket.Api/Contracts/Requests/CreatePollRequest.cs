using SurveyBasket.Api.Contracts.Responses;

namespace SurveyBasket.Api.Contracts.Requests;

public record CreatePollRequest(
     string Title ,
     string Description 
);