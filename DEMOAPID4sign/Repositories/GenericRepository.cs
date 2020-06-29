using DEMOAPID4sign.Interfaces;
using DEMOAPID4sign.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DEMOAPID4sign.Repositories
{
    public class GenericRepository : IGenericRepository
    {
        private string tokenAPI { get; }

        private string cryptKey { get; }

        public GenericRepository()
        {
            this.tokenAPI = "live_07c4206203ceb944918077d7b9d588031a9377b5a3398dc835d12f61d5357c9a";
            this.cryptKey = "live_crypt_ieY1WkjRhXyz0C5JYnWTYOH9lqQTbACG";
        }

        public string GetTokenAPI()
        {
            return this.tokenAPI;
        }

        public string GetCryptKey()
        {
            return this.cryptKey;
        }

        #region Others

        public string GetTypeFile(string type)
        {
            string typeFile = "";

            switch (type)
            {
                case "pdf":
                    typeFile = "application/pdf";
                    break;

                case "doc":
                    typeFile = "application/doc";
                    break;

                case "docx":
                    typeFile = "application/docx";
                    break;

                case "jpg":
                    typeFile = "application/jpg";
                    break;

                case "png":
                    typeFile = "application/png";
                    break;
            }

            return typeFile;
        }

        #endregion

        #region Send/ Download File

        public UploadedFile UploadFile(string nameFile, string pathFile, string uuidCofre, string type, string uuidFolder = "")
        {
            try
            {
                UploadedFile uploadedFile = new UploadedFile();
                string url = $"http://demo.d4sign.com.br/api/v1/documents/{uuidCofre}/upload?tokenAPI={this.tokenAPI}&cryptKey={this.cryptKey}";
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);

                var bytesFile = File.ReadAllBytes(pathFile);
                File.WriteAllBytes(pathFile, bytesFile);

                request.AddFile("file", bytesFile, Path.GetFileName(pathFile), GetTypeFile(type));

                IRestResponse response = client.Execute(request);

                if (response.ResponseStatus == ResponseStatus.Completed)
                {
                    uploadedFile = JsonConvert.DeserializeObject<List<UploadedFile>>(response.Content).First();
                }
                else
                {
                    uploadedFile.statusDescription = response.StatusDescription;
                }

                return uploadedFile;

            }
            catch
            {
                throw;
            }
        }

        public DownloadedFile DownloadFileByUuid(string uuidDocument)
        {
            try
            {
                DownloadedFile downloadedFile = new DownloadedFile();
                string url = $"http://demo.d4sign.com.br/api/v1/documents/{uuidDocument}/download?tokenAPI={this.tokenAPI}&cryptKey={this.cryptKey}";
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);

                IRestResponse response = client.Execute(request);

                if (response.ResponseStatus == ResponseStatus.Completed)
                {
                    downloadedFile = JsonConvert.DeserializeObject<DownloadedFile>(response.Content);
                    System.Diagnostics.Process.Start(downloadedFile.url);

                }
                else
                {
                    downloadedFile.statusDescription = response.StatusDescription;
                }

                return downloadedFile;

            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region Document


        public Document RemoveDocumentByUuid(string uuidDocument)
        {
            try
            {
                Document removedDocument = new Document();
                string url = $"http://demo.d4sign.com.br/api/v1/documents/{uuidDocument}/cancel?tokenAPI={this.tokenAPI}&cryptKey={this.cryptKey}";
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);

                IRestResponse response = client.Execute(request);

                if (response.ResponseStatus == ResponseStatus.Completed)
                {
                    removedDocument = JsonConvert.DeserializeObject<List<Document>>(response.Content).First();

                }
                else
                {
                    removedDocument.statusDescription = response.StatusDescription;
                }

                return removedDocument;

            }
            catch
            {
                throw;
            }
        }

        public List<Document> ListAllDocuments()
        {
            try
            {
                List<Document> documentsList = new List<Document>();
                string url = $"http://demo.d4sign.com.br/api/v1/documents?tokenAPI={this.tokenAPI}&cryptKey={this.cryptKey}";
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);

                IRestResponse response = client.Get(request);

                if (response.ResponseStatus == ResponseStatus.Completed)
                {
                    documentsList = JsonConvert.DeserializeObject<List<Document>>(response.Content);
                    // Removo o primeiro elemento pois não vem no padrão JSON esperado
                    documentsList.RemoveAt(0);

                }
                else
                {
                    Document document = new Document { statusDescription = response.StatusDescription };
                    documentsList.Add(document);
                }

                return documentsList;

            }
            catch
            {
                throw;
            }
        }


        public List<Document> ListAllDocumentsBySafe(string uuidSafe)
        {
            try
            {
                List<Document> documentsList = new List<Document>();
                string url = $"http://demo.d4sign.com.br/api/v1/documents/{uuidSafe}/safe?tokenAPI={this.tokenAPI}&cryptKey={this.cryptKey}";
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);

                IRestResponse response = client.Get(request);

                if (response.ResponseStatus == ResponseStatus.Completed)
                {
                    documentsList = JsonConvert.DeserializeObject<List<Document>>(response.Content);
                    // Removo o primeiro elemento pois não vem no padrão JSON esperado
                    documentsList.RemoveAt(0);

                }
                else
                {
                    Document document = new Document { statusDescription = response.StatusDescription };
                    documentsList.Add(document);
                }

                return documentsList;

            }
            catch
            {
                throw;
            }
        }


        public List<Document> ListAllDocumentsByStatus(int idStatus)
        {
            //ID 1 - Processando ID 2 - Aguardando Signatários ID 3 - Aguardando Assinaturas ID 4 - Finalizado ID 5 - Arquivado ID 6 - Cancelado

            try
            {
                List<Document> documentsList = new List<Document>();
                string url = $"http://demo.d4sign.com.br/api/v1/documents/{idStatus}/status?tokenAPI={this.tokenAPI}&cryptKey={this.cryptKey}";
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);

                IRestResponse response = client.Get(request);

                if (response.ResponseStatus == ResponseStatus.Completed)
                {
                    documentsList = JsonConvert.DeserializeObject<List<Document>>(response.Content);
                    // Removo o primeiro elemento pois não vem no padrão JSON esperado
                    documentsList.RemoveAt(0);

                }
                else
                {
                    Document document = new Document { statusDescription = response.StatusDescription };
                    documentsList.Add(document);
                }

                return documentsList;

            }
            catch
            {
                throw;
            }

        }


        public Document GetDocumentByUuid(string uuidDocument)
        {
            try
            {
                Document document = new Document();
                string url = $"http://demo.d4sign.com.br/api/v1/documents/{uuidDocument}?tokenAPI={this.tokenAPI}&cryptKey={this.cryptKey}";
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);

                IRestResponse response = client.Get(request);

                if (response.ResponseStatus == ResponseStatus.Completed)
                {
                    document = JsonConvert.DeserializeObject<List<Document>>(response.Content).First();

                }
                else
                {
                    document = new Document { statusDescription = response.StatusDescription };

                }

                return document;

            }
            catch
            {
                throw;
            }
        }


        #endregion

        #region Safes

        public List<Safe> ListAllSafes()
        {
            try
            {
                Document documentFirst = new Document();
                List<Safe> safes = new List<Safe>();
                string url = $"http://demo.d4sign.com.br/api/v1/safes?tokenAPI={this.tokenAPI}&cryptKey={this.cryptKey}";
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);

                IRestResponse response = client.Get(request);

                if (response.ResponseStatus == ResponseStatus.Completed)
                {
                    safes = JsonConvert.DeserializeObject<List<Safe>>(response.Content);

                    foreach (var cofre in safes)
                    {
                        documentFirst = ListAllDocumentsBySafe(cofre.uuid_safe).First();
                        cofre.name_safe = documentFirst.safeName;
                    }

                }
                else
                {
                    Safe safe = new Safe { statusDescription = response.StatusDescription };
                    safes.Add(safe);

                }

                return safes;

            }
            catch
            {
                throw;
            }
        }


        #endregion

        #region Folders

        public CreatedFolder CreateFolderBySafe(string nameFolder, string uuidSafe)
        {
            try
            {
                CreatedFolder folder = new CreatedFolder();
                string url = $"http://demo.d4sign.com.br/api/v1/folders/{uuidSafe}/create?tokenAPI={this.tokenAPI}&cryptKey={this.cryptKey}";
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);

                request.AddParameter("folder_name", nameFolder);

                IRestResponse response = client.Post(request);

                if (response.ResponseStatus == ResponseStatus.Completed)
                {
                    folder = JsonConvert.DeserializeObject<CreatedFolder>(response.Content);

                }
                else
                {
                    folder = new CreatedFolder { statusDescription = response.StatusDescription };

                }

                return folder;

            }
            catch
            {
                throw;
            }
        }


        public Message RenameFolderBySafe(string newNameFolder, string uuidFolder, string uuidSafe)
        {
            try
            {
                Message message = new Message();
                string url = $"http://demo.d4sign.com.br/api/v1/folders/{uuidSafe}/rename?tokenAPI={this.tokenAPI}&cryptKey={this.cryptKey}";
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);

                request.AddParameter("folder_name", newNameFolder);
                request.AddParameter("uuid_folder", uuidFolder);

                IRestResponse response = client.Post(request);

                if (response.ResponseStatus == ResponseStatus.Completed)
                {
                    message = JsonConvert.DeserializeObject<Message>(response.Content);
                    message.completed = true;

                }
                else
                {
                    message.statusDescription = response.StatusDescription;
                    message.completed = false;
                }

                return message;

            }
            catch
            {
                throw;
            }
        }


        public List<Folder> ListAllFoldersBySafe(string uuidSafe)
        {
            try
            {
                List<Folder> foldersList = new List<Folder>();
                string url = $"http://demo.d4sign.com.br/api/v1/folders/{uuidSafe}/find?tokenAPI={this.tokenAPI}&cryptKey={this.cryptKey}";
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);

                IRestResponse response = client.Get(request);

                if (response.ResponseStatus == ResponseStatus.Completed)
                {
                    foldersList = JsonConvert.DeserializeObject<List<Folder>>(response.Content);

                }
                else
                {
                    Folder folder = new Folder { statusDescription = response.StatusDescription };
                    foldersList.Add(folder);
                }

                return foldersList;

            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region Signature

        public Signature CreateSignature(string uuidDocument, string emailSignature, char act, char foreign, char certificate)
        {
            try
            {
                Signature signature = new Signature();
                string url = $"http://demo.d4sign.com.br/api/v1/documents/{uuidDocument}/createlist?tokenAPI={this.tokenAPI}&cryptKey={this.cryptKey}";
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);

                request.AddParameter("signers[0][email]", emailSignature);
                request.AddParameter("signers[0][act]", act);
                request.AddParameter("signers[0][foreign]", foreign);
                request.AddParameter("signers[0][certificadoicpbr]", certificate);

                IRestResponse response = client.Post(request);

                if (response.ResponseStatus == ResponseStatus.Completed)
                {
                    signature = JsonConvert.DeserializeObject<SignatureList>(response.Content).message.First();

                }
                else
                {
                    signature = new Signature { statusDescription = response.StatusDescription };

                }

                return signature;

            }
            catch
            {
                throw;
            }
        }

        public Message AlterSignatureByKey(string oldEmail, string newEmail, string keySigner, string uuidDocument)
        {
            try
            {
                Message message = new Message();
                string url = $"http://demo.d4sign.com.br/api/v1/documents/{uuidDocument}/changeemail?tokenAPI={this.tokenAPI}&cryptKey={this.cryptKey}";
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);

                request.AddParameter("email-before", oldEmail);
                request.AddParameter("email-after", newEmail);
                request.AddParameter("key-signer", keySigner);

                IRestResponse response = client.Post(request);

                if (response.ResponseStatus == ResponseStatus.Completed)
                {
                    message = JsonConvert.DeserializeObject<Message>(response.Content);
                    message.completed = true;

                }
                else
                {
                    message.statusDescription = response.StatusDescription;
                    message.completed = false;

                }

                return message;

            }
            catch
            {
                throw;
            }
        }


        public Message RemoveSignature(string emailSigner, string keySigner, string uuidDocument)
        {
            try
            {
                Message message = new Message();
                string url = $"http://demo.d4sign.com.br/api/v1/documents/{uuidDocument}/removeemaillist?tokenAPI={this.tokenAPI}&cryptKey={this.cryptKey}";
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);

                request.AddParameter("email-signer", emailSigner);
                request.AddParameter("key-signer", keySigner);

                IRestResponse response = client.Post(request);

                if (response.ResponseStatus == ResponseStatus.Completed)
                {
                    message = JsonConvert.DeserializeObject<Message>(response.Content);
                    message.completed = true;

                }
                else
                {
                    message.statusDescription = response.StatusDescription;
                    message.completed = false;

                }

                return message;

            }
            catch
            {
                throw;
            }
        }

        public List<InfoSignature> ListAllSignatureByDocument(string uuidDocument)
        {
            try
            {
                List<InfoSignature> infoSignatureList = new List<InfoSignature>();
                string url = $"http://demo.d4sign.com.br/api/v1/documents/{uuidDocument}/list?tokenAPI={this.tokenAPI}&cryptKey={this.cryptKey}";
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);

                IRestResponse response = client.Get(request);

                if (response.ResponseStatus == ResponseStatus.Completed)
                {
                    infoSignatureList = JsonConvert.DeserializeObject<List<InfoSignatureList>>(response.Content).First().list;
                }
                else
                {
                    infoSignatureList = new List<InfoSignature> { new InfoSignature { statusDescription = response.StatusDescription } };

                }

                return infoSignatureList;

            }
            catch
            {
                throw;
            }
        }


        public Clausula CreateTextToSignature(string keySigner, string emailSigner, string text, string uuidDocument)
        {
            try
            {
                Clausula clausula = new Clausula();
                string url = $"http://demo.d4sign.com.br/api/v1/documents/{uuidDocument}/addhighlight?tokenAPI={this.tokenAPI}&cryptKey={this.cryptKey}";
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);

                request.AddParameter("key-signer", keySigner);
                request.AddParameter("email", emailSigner);
                request.AddParameter("text", text);

                IRestResponse response = client.Post(request);

                if (response.ResponseStatus == ResponseStatus.Completed)
                {
                    clausula = JsonConvert.DeserializeObject<Clausula>(response.Content);
                }
                else
                {
                    clausula = new Clausula { statusDescription = response.StatusDescription };

                }

                return clausula;

            }
            catch
            {
                throw;
            }
        }

        public Message SendToSigner(string uuidDocument, char workflow, string message = "")
        {

            /* Opções:
            0 = Para não seguir o workflow.
            1 = Para seguir o workflow.
            Caso o parâmetro workflow seja definido como 1, o segundo signatário só receberá 
            a mensagem de que há um documento aguardando sua assinatura 
            DEPOIS que o primeiro signatário efetuar a assinatura, e assim sucessivamente.*/

            try
            {
                Message msg = new Message();
                string url = $"http://demo.d4sign.com.br/api/v1/documents/{uuidDocument}/sendtosigner?tokenAPI={this.tokenAPI}&cryptKey={this.cryptKey}";
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);

                request.AddParameter("skip_email", 0);
                request.AddParameter("workflow", workflow);

                if (!message.Equals(""))
                    request.AddParameter("message", message);

                IRestResponse response = client.Post(request);

                if (response.ResponseStatus == ResponseStatus.Completed)
                {
                    msg = JsonConvert.DeserializeObject<Message>(response.Content);
                    msg.completed = true;
                }
                else
                {
                    msg.statusDescription = response.StatusDescription;
                    msg.completed = false;

                }

                return msg;

            }
            catch
            {
                throw;
            }
        }

        public Message ResendLinkToSigner(string emailSigner, string keySigner, string uuidDocument)
        {
            try
            {
                Message msg = new Message();
                string url = $"http://demo.d4sign.com.br/api/v1/documents/{uuidDocument}/resend?tokenAPI={this.tokenAPI}&cryptKey={this.cryptKey}";
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);

                request.AddParameter("email", emailSigner);
                request.AddParameter("key-signer", keySigner);

                IRestResponse response = client.Post(request);

                if (response.ResponseStatus == ResponseStatus.Completed)
                {
                    msg = JsonConvert.DeserializeObject<Message>(response.Content);
                    msg.completed = true;
                }
                else
                {
                    msg.statusDescription = response.StatusDescription;
                    msg.completed = false;

                }

                return msg;

            }
            catch
            {
                throw;
            }
        }

        #endregion



    }
}
