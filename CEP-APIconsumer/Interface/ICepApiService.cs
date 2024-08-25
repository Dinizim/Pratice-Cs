using CEP_APIconsumer.Entities;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEP_APIconsumer.Interface;
public interface ICepApiService
{
    [Get("/ws/{cep}/json/")]
    Task<CEPresponse>GetAddresAsync(string cep);
}
