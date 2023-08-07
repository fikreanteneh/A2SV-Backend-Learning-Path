using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

class FileManager {
    
    private static string filePath = Path.Combine(Directory.GetCurrentDirectory(), "student.json");
    
    public static string LineReader() {
        try{
            return File.ReadAllText(filePath);
        }catch{
           return "[]"; 
        }
    }
    
    public static async Task<bool> LineChanger(string[] newData) {
        string message;
        try{
            await File.WriteAllLinesAsync(filePath, newData);
            return true;
        }
        catch(FileNotFoundException ex){
            message = "The File task.csv is Not Found";
        }
        catch(IOException ex){
            message = $"Something Went Wrong while writing. Check your disk!";
        }
        catch(Exception ex){
            message =  "Something Went wrong";
        }
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n{message}\n");
        Console.ForegroundColor = ConsoleColor.White;
        return false;
        
    }
}