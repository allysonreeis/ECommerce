using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Application.Services;
public interface IImageStorageService
{
    Task<string> UploadImageAsync(Stream file, string contentType, CancellationToken cancellationToken);
}
