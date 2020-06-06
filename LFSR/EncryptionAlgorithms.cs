using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LFSR.Attributes;

[Plugin(".lfsr")]
public class EncryptionAlgorithms
{
    const int NUMLFSR = 25;

    public static byte ConvertByte(BitArray bits)
    {
        byte[] bytes = new byte[1];
        bits.CopyTo(bytes, 0);
        return bytes[0];
    }

    public static void SaveInFile(string filePath, string info)
    {
        using (BinaryWriter writer = new BinaryWriter(File.Create(filePath)))
        {
            int j = 0;
            bool[] arr = new bool[8];
            for (int i = 0; i < info.Length; i++)
            {
                arr[i % 8] = info[i] == '1' ? true : false;
                j++;
                if (j == 8)
                {
                    BitArray bitarray = new BitArray(new bool[] { arr[7], arr[6], arr[5], arr[4], arr[3], arr[2], arr[1], arr[0] });
                    byte n = ConvertByte(bitarray);
                    j = 0;
                    writer.Write(n);
                }
            }
        }
    }
    public static void SaveKey(string filePath, string key)
    {
        using (StreamWriter writer = new StreamWriter(File.Create(filePath)))
        {
            writer.WriteLine(key);
        }
    }

    public static string LoadKey(string filePath)
    {
        string key;
        using (StreamReader reader = new StreamReader(File.OpenRead(filePath)))
        {
            key = reader.ReadLine();
        }
        return key;
    }
    public static string GetInitLFSR()
    {
        string res = "";
        Random random = new Random();
        for (int i = 0; i < NUMLFSR; i++)
        {
            if (random.Next(0, 2) == 1)
                res += '1';
            else
                res += '0';
        }
        return res;
    }

    public static string GetInitBits(string filename)
    {
        string InitBits = "";
        long length = new FileInfo(filename).Length;
        byte[] bytes = new byte[length];
        using (BinaryReader reader = new BinaryReader(File.OpenRead(filename)))
        {
            while (reader.BaseStream.Position != reader.BaseStream.Length)
            {
                byte getbyte = reader.ReadByte();
                BitArray bits = new BitArray(new byte[] { getbyte });
                for (int i = bits.Length - 1; i >= 0; i--)
                    InitBits += bits[i] == true ? "1" : "0";
            }
            return InitBits;
        }
    }

    public static string LFSRAction(string lfsr, string fileBits)
    {
        lfsr += "00000000000000000000000000";
        lfsr = lfsr.Remove(NUMLFSR);
        string key = "";
        string crypt = "";
        long xor = 0;
        long PushBit = 0;
        long keyNum = Convert.ToInt64(lfsr, 2);
        long MemXor;
        for (int i = 0; i < fileBits.Length; i++)
        {

            if ((Convert.ToInt64("1000000000000000000000000", 2) & keyNum) == 0)
                PushBit = 0;
            else
                PushBit = 1;

            crypt += Convert.ToString(PushBit ^ (Convert.ToInt64(Convert.ToString(fileBits[i]))));

            if (i < 400)
                key += Convert.ToByte(PushBit);


            if ((Convert.ToInt64("100", 2) & keyNum) == 0)
                MemXor = 0;
            else
                MemXor = 1;

            xor = PushBit ^ MemXor;
            keyNum = keyNum << 1;

            if (PushBit == 1)
                keyNum = keyNum ^ Convert.ToInt64("10000000000000000000000000", 2);

            if (xor != 0)
                keyNum++;
        }
        return crypt;
    }

    public static void Decrypt(string filePath)
    {

        FileDialog fileDialog = new OpenFileDialog();
        fileDialog.Filter = ".txt|*.txt";
        fileDialog.Title = "Открытие ключа";
        if (fileDialog.ShowDialog() == DialogResult.Cancel)
            return;
        string keyBits = LoadKey(fileDialog.FileName);
        string fileBits = GetInitBits(filePath);
        string decryptBits = LFSRAction(keyBits, fileBits);
        SaveInFile(filePath.Substring(0, filePath.Length - 5), decryptBits);
    }

    public static void Encrypt(string filePath)
    {
        string fileBits = GetInitBits(filePath);
        string initLFSR = GetInitLFSR();
        string cryptStr = LFSRAction(initLFSR, fileBits);

        SaveInFile(filePath + ".lfsr", cryptStr);

        FileDialog fileDialog = new SaveFileDialog();
        fileDialog.Filter = ".txt|*.txt";
        fileDialog.Title = "Cохранение ключа";
        if (fileDialog.ShowDialog() == DialogResult.Cancel)
            return;
        string keyPath = fileDialog.FileName;
        SaveKey(keyPath, initLFSR);
    }
}

