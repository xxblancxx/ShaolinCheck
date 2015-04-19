using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace ShaolinCheck
{
    class WSContext
    {
        private HttpClientHandler handler;
        public const string ServerUrl = "http://localhost:17819/api/";
        public async Task<List<Club>> GetAllClubs()
        {
            handler = new HttpClientHandler();
            //Creates a new HttpClientHandler.
            handler.UseDefaultCredentials = true;
            //true if the default credentials are used; otherwise false. will use authentication credentials from the logged on user on your pc.
            using (HttpClient client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                var task = client.GetAsync("clubs");
                // var means the compiler will determine the explicit type of the variable, based on usage. this would give you a variable of type Client.
                HttpResponseMessage response = await task;
                response.EnsureSuccessStatusCode();
                // check for response code (if response is not 200 throw exception)
                var clublist = await response.Content.ReadAsAsync<IEnumerable<Club>>();
                // var will give you a variable of type IEnumerable.
                return clublist.ToList();
            }
        }

        public async Task<ObservableCollection<Team>> GetAllTeams()
        {
            handler = new HttpClientHandler();
            //Creates a new HttpClientHandler.
            handler.UseDefaultCredentials = true;
            //true if the default credentials are used; otherwise false. will use authentication credentials from the logged on user on your pc.
            using (HttpClient client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                var task = client.GetAsync("Teams");
                // var means the compiler will determine the explicit type of the variable, based on usage. this would give you a variable of type Client.
                HttpResponseMessage response = await task;
                response.EnsureSuccessStatusCode();
                // check for response code (if response is not 200 throw exception)
                var teamlist = await response.Content.ReadAsAsync<ObservableCollection<Team>>();
                // var will give you a variable of type IEnumerable.
                return teamlist;
            }
        }

        public async Task<ObservableCollection<Student>> GetAllStudents()
        {
            handler = new HttpClientHandler();
            //Creates a new HttpClientHandler.
            handler.UseDefaultCredentials = true;
            //true if the default credentials are used; otherwise false. will use authentication credentials from the logged on user on your pc.
            using (HttpClient client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                var task = client.GetAsync("Students");
                // var means the compiler will determine the explicit type of the variable, based on usage. this would give you a variable of type Client.
                HttpResponseMessage response = await task;
                response.EnsureSuccessStatusCode();
                // check for response code (if response is not 200 throw exception)
                var studentlist = await response.Content.ReadAsAsync<ObservableCollection<Student>>();
                // var will give you a variable of type IEnumerable.
                return studentlist;
            }
        }

        public async Task<ObservableCollection<Registration>> GetAllRegistrations()
        {
            handler = new HttpClientHandler();
            //Creates a new HttpClientHandler.
            handler.UseDefaultCredentials = true;
            
            //true if the default credentials are used; otherwise false. will use authentication credentials from the logged on user on your pc.
            using (HttpClient client = new HttpClient(handler))
            {
                client.Timeout = TimeSpan.FromSeconds(4);
                client.BaseAddress = new Uri(ServerUrl);
                var task = client.GetAsync("Registrations");
                // var means the compiler will determine the explicit type of the variable, based on usage. this would give you a variable of type Client.
                HttpResponseMessage response = await task;
                response.EnsureSuccessStatusCode();
                // check for response code (if response is not 200 throw exception)
                var registrationlist = await response.Content.ReadAsAsync<ObservableCollection<Registration>>();
                // var will give you a variable of type IEnumerable.
                return registrationlist;
            }
        }

        public async Task CreateRegistration(Registration registration)
        {
            handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = await client.PostAsJsonAsync("Registrations", registration);
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }

            }
        }

    }
}
                                                                                        
                                                                                        
    //                                  ICKBUTTDI                                         
    //                              CKBUTTDICKBUTTDIC                                     
    //                          KBUTTDICKBUTTDICKBUTTDIC                                  
    //                  KBUTTDICKBUTTDI           CKBUTTDI                                
    //               CKBUTTDICKBUT                  TDICKBU                               
    //             TTDICKBUTTDICKB                   UTTDIC                               
    //             KBUTTDICKBUTTDIC                   KBUTT                               
    //             DICKBUTTDIC KBUTTD    ICKBUTTDICK  BUTTD                               
    //             ICKBUTTDICKBUTTDICK BUTTDICKBUTTDIC KBUT                               
    //             TDICKBUTTDICKBUTT  DICKBUTTDICKBUTTDICKB                               
    //            UTTDI  CKBUTTDICKB  UTTDICKBUTTDICKBUTTDI                               
    //           CKBUTTDICKBUTTDICKBU TTDICKBUTTD ICKBUTTDI                               
    //          CKBUTTDICKBUTTDICKB   UTTDICKBUTTDICKBUTTDI                               
    //         CKBUTTDICKBUTTDICKBUTTDICKBUTTDICKBU  TTDIC                                
    //        KBUTT          DICKBUTTDICKBUTTDI     CKBUTT                                
    //       DICKB                      UTTDICK     BUTTDI                                
    //      CKBUTT                                 DICKBU                                 
    //     TTDICK                                 BUTTDI                                  
    //    CKBUTT                                  DICKBU                                  
    //    TTDIC                      KBUT        TDICKB                                   
    //    UTTD                      ICKBU TTD   ICKBUT                                    
    //    TDIC                      KBUTTDICKB  UTTDI                         CKBUTTDIC   
    //   KBUTT                      DICKBUTTD  ICKBU                        TTDICKBUTTDI  
    //   CKBUT                     TDICKBUTTD ICKBU                       TTDICK    BUTT  
    //   DICKB                     UTTDICKBU  TTDIC                     KBUTTDI    CKBUT  
    //   TDICK                    BUTTDICKB  UTTDIC                   KBUTTDI     CKBUT   
    //   TDICK                    BUTTDICK   BUTTDICKBUTTDICKBUTT   DICKBUT     TDICK     
    //    BUTT                   DICKBUTT    DICKBUTTDICKBUTTDICKBUTTDICK      BUTTD      
    //    ICKB                   UTTDICK     BUTTD   ICKBU   TTDICKBUTT      DICKBU       
    //    TTDI                  CKBUTTDI      CKB   UTTDICKBUTTDICKBU      TTDICK         
    //    BUTTD               ICKBU TTDIC         KBUTTDICKBUTTDICKB     UTTDICK          
    //     BUTT             DICKB  UTTDICK         BUTTDICKBUTTDICKBUT   TDICKBUT         
    //     TDICK            BUTTDICKBUTTDI                     CKBUTTDI    CKBUTTDIC      
    //      KBUTT            DICKBUTTDICK              BUTT       DICKBU  TTDI CKBUT      
    //      TDICKB              UTTD                   ICKB        UTTDIC  KBUTTDIC       
    //       KBUTTD                                ICK              BUTTD    ICKB         
    //        UTTDICKB                            UTTD              ICKBU     TTDI        
    //           CKBUTTD                          ICKB              UTTDICKBUTTDIC        
    // KBU        TTDICKBUTT                       DICK           BUTTDICKBUTTDIC         
    //KBUTTDI    CKBUTTDICKBUTTDIC                  KBU         TTDICKB    U              
    //TTDICKBUTTDICK BUTTDICKBUTTDICKBUTTD           ICKB    UTTDICK                      
    //BUTT DICKBUTTDICKBU    TTDICKBUTTDICKB UTTDICKBUTTDICKBUTTDI                        
    // CKBU  TTDICKBUTT         DICKBUTTDIC KBUTTDICKBUTTDICKBU                           
    //  TTDI   CKBUTT         DICKBUTTDICK BUTTD ICKBUTTDICK                              
    //   BUTTDICKBU           TTDICKBUTTD  ICKB                                           
    //    UTTDICK              BUTTDICK   BUTT                                            
    //      DIC                KBUTTD    ICKB                                             
    //                          UTTDIC  KBUT                                              
    //                           TDICKBUTTD                                               
    //                             ICKBUTT                                                
    //                               DIC                                                  
                                                                                        