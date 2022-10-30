using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using Excel;
using System.Data;

//Editor Script
public static class MyEditor
{
    [MenuItem("�ҵĹ���/excelת��txt")]
    public static void ExportExcelToTxt()
    {
        //_Excel�ļ���·��
        string assetPath = Application.dataPath + "/_Excel";

        //Gain _Excel�ļ����е� excel�ļ�
        string[] files = Directory.GetFiles(assetPath, "*.xlsx");

        for (int i = 0; i < files.Length; i++)
        {
            files[i] = files[i].Replace('\\', '/');//��б���滻����б��

            using (FileStream fs = File.Open(files[i], FileMode.Open, FileAccess.Read))
            {
                var excelDataReader = ExcelReaderFactory.CreateOpenXmlReader(fs);

                //Gain excel data
                DataSet dataSet = excelDataReader.AsDataSet();

                //Read excel first table
                DataTable table = dataSet.Tables[0];

                readTableToTxt(files[i], table);
            }
        }
        AssetDatabase.Refresh();
    }
    private static void readTableToTxt(string filePath, DataTable table)
    {
        //Gain file's name
        string fileName = Path.GetFileNameWithoutExtension(filePath);

        string path = Application.dataPath + "/Resources/Data/" + fileName + ".txt";

        if (File.Exists(path))
        {
            File.Delete(path);
        }
        using (FileStream fs = new FileStream(path, FileMode.Create))
        {
            using (StreamWriter sw = new StreamWriter(fs))
            {
                //�ļ���תд���� ����д���ַ���
                for (int row = 0; row < table.Rows.Count; row++)
                {
                    DataRow dataRow = table.Rows[row];

                    string str = "";

                    for (int col = 0; col < table.Columns.Count; col++)
                    {
                        string val = dataRow[col].ToString();

                        str = str + val + "\t";
                    }
                    sw.Write(str);

                    if (row != table.Rows.Count - 1)
                    {
                        sw.WriteLine();
                    }
                }
            }
        }
    }
}
