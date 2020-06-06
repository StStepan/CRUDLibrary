using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RC4.Attributes;

[Plugin(".rc4")]
class EncryptionAlgorithms
{
    const int NUMELSBOX = 256;

    public static byte ConvertByte(BitArray bits)
    {
        byte[] bytes = new byte[1];
        bits.CopyTo(bytes, 0);
        return bytes[0];
    }
    public static void InitSBox(byte[] sBox, byte[] keyBytes)
    {
        byte j = 0, tmp = 0;
        for (int i = 0; i < NUMELSBOX; i++)
            sBox[i] = Convert.ToByte(i);

        for (int i = 0; i < NUMELSBOX; i++)
        {
            j = Convert.ToByte((j + sBox[i] + keyBytes[i % keyBytes.Length]) % NUMELSBOX);
            tmp = sBox[i];
            sBox[i] = sBox[j];
            sBox[j] = tmp;
        }
    }

    public static byte[] Action(byte[] fileBytes, byte[] keyBytes)
    {
        byte[] sBox = new byte[NUMELSBOX];
        byte[] cryptBytes = new byte[fileBytes.Length];
        byte i = 0, j = 0, tmp = 0, KeyByte = 0;
        InitSBox(sBox, keyBytes);
        for (int k = 0; k < fileBytes.Length; k++)
        {
            i = Convert.ToByte((i + 1) % NUMELSBOX);
            j = Convert.ToByte((j + sBox[i]) % NUMELSBOX);
            tmp = sBox[i];
            sBox[i] = sBox[j];
            sBox[j] = tmp;
            KeyByte = sBox[(sBox[i] + sBox[j]) % NUMELSBOX];
            cryptBytes[k] = Convert.ToByte(KeyByte ^ fileBytes[k]);
        }
        return cryptBytes;
    }

    public static byte[] GetKeyBytes()
    {
        Random random = new Random();
        int value = random.Next(2, 10);
        byte[] keyArray = new byte[value];
        for (int i = 0; i < keyArray.Length; i++)
            keyArray[i] = Convert.ToByte(random.Next(0, 255));
        return keyArray;
    }

    public static void Encrypt(string filePath)
    {
        FileInfo file = new FileInfo(filePath);
        long size = file.Length;
        byte[] initBytes;
        using (BinaryReader reader = new BinaryReader(File.OpenRead(filePath)))
        {
            initBytes = reader.ReadBytes(Convert.ToInt32(size));
        }

        FileDialog fileDialog = new SaveFileDialog();

        byte[] keyBytes = GetKeyBytes();
        byte[] cryptBytes = Action(initBytes, keyBytes);

        using (BinaryWriter writer = new BinaryWriter(File.Create(filePath + ".rc4")))
        {
            for (int i = 0; i < cryptBytes.Length; i++)
                writer.Write(cryptBytes[i]);
        }
        File.Delete(filePath);

        fileDialog.Filter = ".dat|*.dat";
        fileDialog.Title = "Cохранение ключа";
        if (fileDialog.ShowDialog() == DialogResult.Cancel)
            return;
        string keyPath = fileDialog.FileName;
        using (BinaryWriter writer = new BinaryWriter(File.Create(keyPath)))
        {
            for (int i = 0; i < keyBytes.Length; i++)
                writer.Write(keyBytes[i]);
        }
    }

    public static void Decrypt(string filePath)
    {
        FileDialog fileDialog = new OpenFileDialog();
        fileDialog.Filter = ".dat|*.dat";
        fileDialog.Title = "Открытие ключа";
        if (fileDialog.ShowDialog() == DialogResult.Cancel)
            return;
        FileInfo file = new FileInfo(fileDialog.FileName);
        long size = file.Length;
        byte[] keyBytes;
        using (BinaryReader reader = new BinaryReader(File.OpenRead(fileDialog.FileName)))
        {
            keyBytes = reader.ReadBytes(Convert.ToInt32(size));
        }
        file = new FileInfo(filePath);
        size = file.Length;
        byte[] cryptBytes;
        using (BinaryReader reader = new BinaryReader(File.OpenRead(filePath)))
        {
            cryptBytes = reader.ReadBytes(Convert.ToInt32(size));
        }
        byte[] decryptBytes = Action(cryptBytes, keyBytes);
        using (BinaryWriter writer = new BinaryWriter(File.Create(filePath.Substring(0, filePath.Length - 4))))
        {
            for (int i = 0; i < decryptBytes.Length; i++)
                writer.Write(decryptBytes[i]);
        }
    }
}
