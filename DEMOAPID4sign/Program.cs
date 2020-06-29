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

                //var response = genericRepository.UploadFile("Send test file", @"pathFile", "uuidSafe", "typeFile", "uuidFolder");                                

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
