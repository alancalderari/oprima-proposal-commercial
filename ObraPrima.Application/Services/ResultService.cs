﻿using FluentValidation.Results;
using ObraPrima.Application.DTOs.Proposal;

namespace ObraPrima.Application.Services;

public class ResultService
{
    public bool IsSuccess { get; private set; } = true;
    public string Message { get; set; } = string.Empty;
    public ICollection<ErrorValidation> Errors { get; set; } = null!;

    public static ResultService RequestError(string message, ValidationResult validationResult)
    {
        return new ResultService
        {
            IsSuccess = false,
            Message = message,
            Errors = validationResult.Errors.Select(x => new ErrorValidation { Field = x.PropertyName, Message = x.ErrorMessage }).ToList()
        };
    }
   
    public static ResultService<T> RequestError<T>(string message, ValidationResult validationResult)
    {
        return new ResultService<T>
        {
            IsSuccess = false,
            Message = message,
            Errors = validationResult.Errors.Select(x => new ErrorValidation { Field = x.PropertyName, Message = x.ErrorMessage }).ToList()
        };
    }
   
    public static ResultService Fail(string message) => new ResultService { IsSuccess = false, Message = message };
    public static ResultService<T> Fail<T>(string message) => new ResultService<T> { IsSuccess = false, Message = message };

    public static ResultService Ok(string message) => new ResultService { Message = message, IsSuccess = true };
    public static ResultService<T> Ok<T>(T data) => new ResultService<T> { Data = data, IsSuccess = true };
}

public class ResultService<T> : ResultService
{
    public T Data { get; set; }
}