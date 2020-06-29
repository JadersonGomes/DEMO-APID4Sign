using DEMOAPID4sign.Interfaces;
using DEMOAPID4sign.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMOAPID4sign
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                IGenericRepository genericRepository = new GenericRepository();

                //var response = genericRepository.UploadFile("Send test file", @"C:/Users/Teste/Desktop/Certificado JavaScript - Alura.pdf", "84c1f067-87f5-4dc3-a9ad-f092635f3eb5", "pdf");
                //genericRepository.DownloadFileByUuid("0e9aeb04-f543-42e8-a3e4-267a29d343df");
                //genericRepository.ListAllSafes();
                //genericRepository.ListAllDocumentsBySafe("84c1f067-87f5-4dc3-a9ad-f092635f3eb5");
                //genericRepository.ListAllDocumentsByStatus(1);
                //genericRepository.GetDocumentByUuid("f98688ed-7a09-4f43-8b57-2cee5e768bc4");
                //genericRepository.ListAllDocuments();
                //genericRepository.CreateFolderBySafe("TestFolder2", "84c1f067-87f5-4dc3-a9ad-f092635f3eb5");
                //genericRepository.ListAllFoldersBySafe("84c1f067-87f5-4dc3-a9ad-f092635f3eb5");
                //genericRepository.RenameFolderBySafe("TesteFolder-Alter", "c8c22fd9-0e27-448e-8c52-2fa22d53472e", "84c1f067-87f5-4dc3-a9ad-f092635f3eb5");
                //genericRepository.RemoveDocumentByUuid("f98688ed-7a09-4f43-8b57-2cee5e768bc4");
                //genericRepository.CreateSignature("f98688ed-7a09-4f43-8b57-2cee5e768bc4", "emailSignature18@teste.com", '1', '0', '0');
                //genericRepository.RemoveSignature("emailSignature17@teste.com", "ODg4ODE=", "f98688ed-7a09-4f43-8b57-2cee5e768bc4");
                //genericRepository.ListAllSignatureByDocument("f98688ed-7a09-4f43-8b57-2cee5e768bc4");
                //genericRepository.AlterSignatureByKey("emailSignature0@teste.com", "jadersonvieira@afresp.org.br", "ODg4NTA=", "f98688ed-7a09-4f43-8b57-2cee5e768bc4");               
                //genericRepository.CreateTextToSignature("ODg4NTA=", "emailSignature0@teste.com", "Sending text to test form send.", "f98688ed-7a09-4f43-8b57-2cee5e768bc4");
                genericRepository.ListAllSignatureByDocument("6045261b-da81-46b2-81fa-736313130e79");
                //genericRepository.ResendLinkToSigner("jadersonvieira@afresp.org.br", "ODgzNTk=", "6045261b-da81-46b2-81fa-736313130e79");
                //genericRepository.SendToSigner("f98688ed-7a09-4f43-8b57-2cee5e768bc4", '0');

                //Console.WriteLine($"Status: {response.ErrorMessage}");
                //Console.WriteLine("");
                //Console.WriteLine($"Conteúdo: {response.Content}");

                Console.ReadKey();

            }
            catch(Exception ex)
            {
                Console.WriteLine($"Mensagem de erro: {ex.Message} \n\nMais detalhes: {ex.StackTrace}");
                Console.ReadKey();
            }

        }
    }
}
