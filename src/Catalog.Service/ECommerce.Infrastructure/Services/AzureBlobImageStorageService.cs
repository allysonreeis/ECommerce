using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using ECommerce.Catalog.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Services;
public class AzureBlobImageStorageService : IImageStorageService
{
    private readonly BlobServiceClient _blobServiceClient;

    public AzureBlobImageStorageService(BlobServiceClient blobServiceClient)
    {
        _blobServiceClient = blobServiceClient;
    }

    public async Task<string> UploadImageAsync(Stream file, string contentType, CancellationToken cancellationToken)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient("teste");
        //await containerClient.CreateIfNotExistsAsync(cancellationToken: cancellationToken);

        var blobClient = containerClient.GetBlobClient(Guid.NewGuid().ToString());
        await blobClient.UploadAsync(file, new BlobUploadOptions
        {
            HttpHeaders = new BlobHttpHeaders
            {
                ContentType = contentType
            }
        }, cancellationToken: cancellationToken);

        return blobClient.Uri.ToString();
    }
}
