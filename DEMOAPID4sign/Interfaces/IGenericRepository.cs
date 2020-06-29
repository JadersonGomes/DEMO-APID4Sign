using DEMOAPID4sign.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMOAPID4sign.Interfaces
{
    public interface IGenericRepository
    {
        UploadedFile UploadFile(string nameFile, string pathFile, string uuidCofre, string type, string uuidFolder = "");

        DownloadedFile DownloadFileByUuid(string uuidDocument);

        List<Safe> ListAllSafes();

        List<Document> ListAllDocumentsBySafe(string uuidSafe);

        List<Document> ListAllDocumentsByStatus(int idFase);

        Document GetDocumentByUuid(string uuidDocument);

        Document RemoveDocumentByUuid(string uuidDocument);

        List<Document> ListAllDocuments();

        CreatedFolder CreateFolderBySafe(string nameFolder, string uuidSafe);

        List<Folder> ListAllFoldersBySafe(string uuidSafe);

        Message RenameFolderBySafe(string newNameFolder, string uuidFolder, string uuidSafe);              

        Signature CreateSignature(string uuidDocument, string emailSignature, char act, char foreign, char certificate);

        Message AlterSignatureByKey(string oldEmail, string newEmail, string keySigner, string uuidDocument);

        Clausula CreateTextToSignature(string keySigner, string emailSigner, string text, string uuidDocument);

        Message SendToSigner(string uuidDocument, char workflow, string message = "");

        Message ResendLinkToSigner(string emailSigner, string keySigner, string uuidDocument);

        Message RemoveSignature(string emailSigner, string keySigner, string uuidDocument);

        List<InfoSignature> ListAllSignatureByDocument(string uuidDocument);

        string GetTypeFile(string type);

        string GetTokenAPI();

        string GetCryptKey();



        //Task ListAllSafesAsync();
    }
}
