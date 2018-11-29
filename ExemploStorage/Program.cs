using System;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Table;

namespace ExemploStorage
{
    class Program
    {
        static void Main(string[] args)
        {
            CloudStorageAccount account = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=storage13net;AccountKey=AhDlxuw3BZ3XhhFvgJUNmvVDBoiUZFXwrZoty/hLCiXdFzR2B/wXVnzlbS/dnRIt7oC/jn8mcvNYoaDluvercg==;EndpointSuffix=core.windows.net");
            #region blob
            var blobClient = account.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference("331850");
            container.CreateIfNotExistsAsync().Wait();
            var blob = container.GetBlockBlobReference("thiago3.txt");
            blob.UploadTextAsync("HOCUS POCUS");
            var sas = blob.GetSharedAccessSignature(new SharedAccessBlobPolicy {
                Permissions = SharedAccessBlobPermissions.Read,
                SharedAccessExpiryTime = DateTime.Now.AddYears(5)
            });
            Console.WriteLine(blob.Uri + sas);
            #endregion

            var client= account.CreateCloudTableClient();
            var table = client.GetTableReference("rm331850");
            table.CreateIfNotExistsAsync().Wait();

            var entity = new Aluno("331850", "sao paulo");
            entity.Nome = "thiao";
            entity.Email = "thiagopbarnabe@gmail.com";

            //TableOperation.Retrieve("")
            table.ExecuteAsync(TableOperation.Insert(entity));

            Console.Read(); 
        }
    }
}
