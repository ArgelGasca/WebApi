using System;

public class AccederTabla
{
	public void AccederTabla()
	{
        #if USINGPROJECTSYSTEM
                    string strAccessConn = "Provider=VFPOLEDB.1;Data Source=C:\\Users\\Argel\\Documents\\Visual FoxPro Projects";
        #else
                string strAccessConn = "Provider=VFPOLEDB.1;Data Source=C:\\Users\\Argel\\Documents\\Visual FoxPro Projects";
        #endif
        string strAccessSelect = "SELECT * FROM sv_artic";
        DataSet myDataSet = new DataSet();
        OleDbConnection myAccessConn = null;
        myAccessConn = new OleDbConnection(strAccessConn);
        OleDbCommand myAccessCommand = new OleDbCommand(strAccessSelect, myAccessConn);
        OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

        myAccessConn.Open();
        myDataAdapter.Fill(myDataSet, "av_artic");
        myAccessConn.Close();
    }
}
