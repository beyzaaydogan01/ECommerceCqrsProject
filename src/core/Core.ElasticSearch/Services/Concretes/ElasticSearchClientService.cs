﻿using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using Core.ElasticSearch.Services.Abstracts;
using Nest;

namespace Core.ElasticSearch.Services.Concretes;

public class ElasticSearchClientService : IElasticSearchClientService
{
    private readonly IElasticClient _elasticClient;

    public ElasticSearchClientService(IElasticClient elasticClient)
    {
        _elasticClient = elasticClient;
    }

    public async Task IndexDocumentAsync<T>(T document, string indexName) where T : class
    {
        var response = await _elasticClient.IndexAsync(document, idx => idx.Index(indexName));

        if (!response.IsValid)
        {
            throw new BusinessException(response.OriginalException.Message);
        }
    }

    public Task<List<T>> SearchAsync<T>(string indexName) where T : class
    {
        throw new NotImplementedException();
    }
}
