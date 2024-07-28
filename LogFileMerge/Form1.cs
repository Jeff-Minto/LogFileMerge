using LogFileMerge.Repositories.LogFileMergeRepository;

namespace LogFileMerge
{
    public partial class Form1 : Form
    {
        private readonly ILogsMergeRepository _mergeRep;
                    
        public Form1(ILogsMergeRepository mergeRep)
        {
            InitializeComponent();
            _mergeRep = mergeRep;

            messagesLbl.Height = 25;
            messagesLbl.Width = 100;
        }

        private void Form1_Load(object sender, EventArgs e)
        {          
            // Populate default input log file folders
            // Move to config files if time permits
            checkedListBox1.Items.Add(@"C:\logfiles\log1\");
            checkedListBox1.Items.Add(@"C:\logfiles\log2\");
            checkedListBox1.Items.Add(@"C:\logfiles\log3\");

            // Populate default archive file folder
            FileArchiveLocationTextBox.Text = @"C:\logfiles\archive\";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            messagesLbl.Text = "Processing statrted...";

            string archiveFolderPath = FileArchiveLocationTextBox.Text;

            List<string?> logFiles = new List<string?>();

            foreach (var item in checkedListBox1.CheckedItems)
            {               
                logFiles.Add(item.ToString());
            }

            try
            {
                messagesLbl.Text = _mergeRep.MergeLogFiles(logFiles, archiveFolderPath);
            }
            catch (Exception ex)
            {
                messagesLbl.Text = ex.Message;
            }                       
        }       
    }
}
