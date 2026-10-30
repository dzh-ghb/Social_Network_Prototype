global using MediatR;
global using Microsoft.AspNetCore.Diagnostics;
global using Microsoft.AspNetCore.Mvc;

global using Api;
global using Api.Exceptions.Handler;
global using Application;
global using Application.Dtos;
global using Application.Exceptions;
global using Application.Topics.Commands.CreateTopic;
global using Application.Topics.Commands.DeleteTopic;
global using Application.Topics.Commands.UpdateTopic;
global using Application.Topics.Queries.GetTopic;
global using Application.Topics.Queries.GetTopics;
global using Infrastructure;
global using Infrastructure.Data.Extensions;

// global using Application.Topics.Old;