using PlayFab;
using PlayFab.ClientModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LauncherTest
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
        }

        public void button1_Click(object sender, EventArgs e)
        {
           
            PlayFabSettings.TitleId = "850C";
            //var req = new RegisterPlayFabUserRequest { TitleId = "850C", Email = "gourav.k.24@gmail.com", Password = "nanobots@2411", RequireBothUsernameAndEmail = false, DisplayName = "Gourav" };
            //var loginTask = PlayFabClientAPI.RegisterPlayFabUserAsync(req);
            //var loginTask = PlayFabClientAPI.LoginWithEmailAddressAsync(new PlayFab.ClientModels.LoginWithEmailAddressRequest { TitleId = "850C", Email = textBox1.Text, Password = textBox2.Text });
            var loginTask = PlayFabClientAPI.LoginWithEmailAddressAsync(new PlayFab.ClientModels.LoginWithEmailAddressRequest { TitleId = "850C", Email = "alexa@amazon.com", Password = "123456" });
            OnLoginComplete(loginTask);

            

            //  var getRequest = new PlayFab.ClientModels.GetTitleDataRequest();

        }

      


        private static void OnLoginComplete(Task<PlayFabResult<LoginResult>> taskResult)
        {

            //Task<PlayFabResult<LoginResult>> task = taskResult;
            Task task = null;
            //TaskScheduler uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            //CancellationTokenSource taskCancelSource = new CancellationTokenSource();
            //CancellationToken taskToken = taskCancelSource.Token;
            task = Task.Factory.StartNew(() =>
            {
                PlayFabSettings.TitleId = "850C";

                var apiError = taskResult.Result.Error;
                var apiResult = taskResult.Result.Result;
                Console.WriteLine("HELLO" + apiError);
                var apiErrorCode = PlayFabUtil.GetErrorReport(apiError);
                Console.WriteLine("3");
                if (apiError != null)
                {
                    //Console.ForegroundColor = ConsoleColor.Red; // Make the error more visible
                    //Console.WriteLine("Something went wrong with your first API call.  :(");
                    MessageBox.Show("Something went wrong with your first API call.  :(");
                    //Console.WriteLine("Here's some debug information:");
                    Console.WriteLine(PlayFabUtil.GetErrorReport(apiError));
                    //Console.ForegroundColor = ConsoleColor.Gray; // Reset to normal
                    Console.WriteLine("4");
                }
                else if (apiResult != null)
                {
                    Console.WriteLine("Congratulations, you made your first successful API call!");
                    MessageBox.Show("" + apiResult);
                }

            });


            //    }, CancellationToken.None, TaskCreationOptions.None, uiScheduler);



            //taskResult = Task<PlayFabResult<LoginResult>>.WaitAll();
            //                    Task.WaitAll(new[] { taskResult});

            Console.WriteLine("6");
            
        }
        
        private static void OntitledataComplete(Task<PlayFabResult<GetTitleDataResult>> taskResult)
        {

            //Task<PlayFabResult<LoginResult>> task = taskResult;
            Task task = null;
            //TaskScheduler uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            //CancellationTokenSource taskCancelSource = new CancellationTokenSource();
            //CancellationToken taskToken = taskCancelSource.Token;
            task = Task.Factory.StartNew(() =>
            {

                try
                {
                    var apiError = taskResult.Result.Error;
                    var apiResult = taskResult.Result.Result;
                    Console.WriteLine("HELLO" + apiError);
                    var apiErrorCode = PlayFabUtil.GetErrorReport(apiError);
                    Console.WriteLine("3");
                    if (apiError != null)
                    {
                        //Console.ForegroundColor = ConsoleColor.Red; // Make the error more visible
                        //Console.WriteLine("Something went wrong with your first API call.  :(");
                        MessageBox.Show("Something went wrong with your first API call.  :(");
                        //Console.WriteLine("Here's some debug information:");
                        Console.WriteLine(PlayFabUtil.GetErrorReport(apiError));
                        //Console.ForegroundColor = ConsoleColor.Gray; // Reset to normal
                        Console.WriteLine("4");
                    }
                    else if (apiResult != null)
                    {
                        Console.WriteLine("Congratulations, you made your first successful API call!");
                        MessageBox.Show("Congratulations, you made your first successful API call!" + "TaskResult Status" + taskResult.Status + "TaskResult" + taskResult.Result.Result.Data + taskResult.Result.ToString());
                        foreach(KeyValuePair<string,string> entry in taskResult.Result.Result.Data)
                        {
                            MessageBox.Show(entry.Value);
                        }
                    }
                }
                catch (AggregateException ae)
                {
                    MessageBox.Show("" + ae);
                }
            });
               
            }
        
            //    }, CancellationToken.None, TaskCreationOptions.None, uiScheduler);



            //taskResult = Task<PlayFabResult<LoginResult>>.WaitAll();
            //                    Task.WaitAll(new[] { taskResult});

           // Console.WriteLine("6");
           
                    public void button2_Click(object sender, EventArgs e)
                    {
                        this.Hide();
                        Register ss = new Register();
                        ss.Show();
                    }

                    private void button3_Click(object sender, EventArgs e)
                    {
                        this.Hide();
                        Forget ss = new Forget();
                        ss.Show();
                    }
           
            private void button4_Click(object sender, EventArgs e)
            {
            //var titledata = PlayFabClientAPI.GetTitleDataAsync(new PlayFab.ClientModels.GetTitleDataRequest { Keys = { "Coins" } });
            //MessageBox.Show("Something went wrong with your first API call.  :(" + titledata);
            
            try
            {
                var titledata = PlayFabClientAPI.GetTitleDataAsync(new PlayFab.ClientModels.GetTitleDataRequest { Keys = new List<string> { "Coins" } });
                OntitledataComplete(titledata);
                //  MessageBox.Show("Something went wrong with your first API call.  :(" + titledata);
            }
            catch (NullReferenceException nre)
            {
                MessageBox.Show("NullReferenceException: " + nre);
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var titlenews = PlayFabClientAPI.GetTitleNewsAsync(new PlayFab.ClientModels.GetTitleNewsRequest { Count = 1});
            OntitlenewsComplete(titlenews);


        }

        private static void OntitlenewsComplete(Task<PlayFabResult<GetTitleNewsResult>> taskResult)
        {

            //Task<PlayFabResult<LoginResult>> task = taskResult;
            Task task = null;
            //TaskScheduler uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            //CancellationTokenSource taskCancelSource = new CancellationTokenSource();
            //CancellationToken taskToken = taskCancelSource.Token;
            task = Task.Factory.StartNew(() =>
            {
                PlayFabSettings.TitleId = "850C";

                var apiError = taskResult.Result.Error;
                var apiResult = taskResult.Result.Result;
                Console.WriteLine("HELLO" + apiError);
                var apiErrorCode = PlayFabUtil.GetErrorReport(apiError);
                Console.WriteLine("3");
                if (apiError != null)
                {
                    //Console.ForegroundColor = ConsoleColor.Red; // Make the error more visible
                    //Console.WriteLine("Something went wrong with your first API call.  :(");
                    MessageBox.Show("Something went wrong with your first API call.  :(");
                    //Console.WriteLine("Here's some debug information:");
                    Console.WriteLine(PlayFabUtil.GetErrorReport(apiError));
                    //Console.ForegroundColor = ConsoleColor.Gray; // Reset to normal
                    Console.WriteLine("4");
                }
                else if (apiResult != null)
                {
                  //  Console.WriteLine("Congratulations, you made your first successful API call!");
                    //MessageBox.Show("" + apiResult.News);
                    foreach (var news in apiResult.News)
                    {
                        Console.WriteLine(news.Body);
                        MessageBox.Show("" + news.Body);
                    }
                }

            });


            //    }, CancellationToken.None, TaskCreationOptions.None, uiScheduler);



            //taskResult = Task<PlayFabResult<LoginResult>>.WaitAll();
            //                    Task.WaitAll(new[] { taskResult});

            Console.WriteLine("6");

        }
    }
}


