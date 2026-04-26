using MiniPatientenVerwaltung;
using System;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

List<Patient> patientenListe = new List<Patient>();
int id = 1;


while (true)
{
    Console.WriteLine("Gib 1 an, um einen Patienten anzulegen, 2 um alle Patienten anzuzeigen 3 um einen Patienten zu bearbeiten, 4 um einen Patienten zu suchen, 5 um einen Patienten zu löschen und 6 um zu das Programm zu beenden.\n");
    string auswahl = Console.ReadLine();


    switch (auswahl)
    {
        case "1":
            LegePatientenAn(patientenListe);
            break;
        case "2":
            if (patientenListe.Count == 0)
            {
                Console.WriteLine("Patientenliste leer - bitte legen Sie einen Patienten an.\n");
            }
            else
            {
                ZeigePatientenAn(patientenListe);
            }
            break;
        case "3":
            BearbeitePatienten(patientenListe);
            break;
        case "4":
            SuchePatienten(patientenListe);
            break;
        case "5":
            LoeschePatienten(patientenListe);
            break;
        case "6":
            Console.WriteLine("Programm beendet.\n");
            return;

        default:
            Console.WriteLine("Falscher Wert.\n");
            break;
    }
}

void LegePatientenAn(List<Patient> patientenListe)
{

    Console.Write("Bitte gib den Namen des Patienten an:\n");
    string name = Console.ReadLine();

    Console.Write("Bitte gib das Geburtsdatum des Patienten an:\n");
    DateTime geburtsdatum = Convert.ToDateTime(Console.ReadLine());

    Console.Write("Bitte gib die Sozialversicherungsnummer des Patienten an:\n");
    int versicherungsnummer = Convert.ToInt32(Console.ReadLine());

    Patient patient = new Patient { Id = id++, Name = name, Geburtsdatum = geburtsdatum, Versicherungsnummer = versicherungsnummer };
    patientenListe.Add(patient);

    Console.WriteLine($"Patient {patient.Name} wurde erfolgreich angelegt.\n");
}

void ZeigePatientenAn(List<Patient> patientenListe)
{
    foreach (Patient patient in patientenListe)
    {
        Console.WriteLine($"ID: {patient.Id} Name: {patient.Name} Geburtsdatum: {patient.Geburtsdatum:dd.MM.yyyy} Sozialversicherungsnummer: {patient.Versicherungsnummer}\n");
    }
}

void BearbeitePatienten(List<Patient> patientenListe)
{
    Console.WriteLine("Bitte gib die ID von dem zu bearbeitenden Patienten an:\n");
    int id = Convert.ToInt32(Console.ReadLine());

    Patient p = patientenListe.Find(x => x.Id == id);

    if (p != null)
    {
        Console.WriteLine("Gib 1 an, um den Namen zu bearbeiten, 2 um das Geburtsdatum zu bearbeiten, 3 um die Sozialversicherungsnummer zu bearbeiten und 4 um das Programm zu beenden.\n");
        string auswahl = Console.ReadLine();

        switch (auswahl)
        {
            case "1":
                BearbeiteNamen(patientenListe);
                break;
            case "2":
                BearbeiteGeburtstag(patientenListe);
                break;
            case "3":
                BearbeiteSozialversicherung(patientenListe);
                break;
            case "4":
                Console.WriteLine("Programm beendet.\n");
                return;
            default:
                Console.WriteLine("Falscher Wert.\n");
                break;
        }


    }

    else
    {
        Console.WriteLine("Patient nicht gefunden.\n");
    }

    void BearbeiteNamen(List<Patient> patientenListe)
    {
        Console.WriteLine($"Alter Name: {p.Name}\n");

        Console.WriteLine("Bitte gib den neuen Namen des Patienten an:\n");
        string name = Console.ReadLine();
        p.Name = name;
        Console.WriteLine("Der Name des Patienten wurde erfolgreich geändert!\n");
    }

    void BearbeiteGeburtstag(List<Patient> patientenListe)
    {
        Console.WriteLine($"Altes Geburtsdatum: {p.Geburtsdatum}\n");

        Console.WriteLine("Bitte gib das neue Geburtsdatum des Patienten an:\n");
        DateTime geburtsdatum = Convert.ToDateTime(Console.ReadLine());
        p.Geburtsdatum = geburtsdatum;

        Console.WriteLine("Das Geburtsdatum des Patienten wurde erfolgreich geändert!\n");
    }

    void BearbeiteSozialversicherung(List<Patient> patientenListe)
    {
        Console.WriteLine($"Alte Sozialversicherungsnummer des Patienten: {p.Versicherungsnummer}\n");

        Console.WriteLine("Bitte gib die neue Sozialversicherungsnummer des Patienten an:\n");
        int versicherungsnummer = Convert.ToInt32(Console.ReadLine());
        p.Versicherungsnummer = versicherungsnummer;

        Console.WriteLine("Die Sozialversicherungsnummer des Patienten wurde erfolgreich geändert!\n");
    }
}
void SuchePatienten(List<Patient> patientenListe)
{

    Console.WriteLine("Gib 1 an um nach dem Namen des Patienten zu suchen, 2 um nach der Sozialversicherungsnummer des Patienten zu suchen und 3 um das Programm zu beenden.\n");
    string auswahl = Console.ReadLine();

    switch (auswahl)
    {
        case "1":
            SucheNamen(patientenListe);
            break;
        case "2":
            SucheSozialversicherung(patientenListe);
            break;
        case "3":
            Console.WriteLine("Programm beendet.\n");
            return;
        default:
            Console.WriteLine("Falscher Wert.\n");
            break;
    }

    void SucheNamen(List<Patient> patientenListe)
    {
        Console.WriteLine("Bitte gib den Namen des Patienten an, nach dem du suchen möchtest:\n");
        string name = Console.ReadLine();

        List<Patient> patient = patientenListe
        .Where(p => p.Name.StartsWith(name, StringComparison.OrdinalIgnoreCase))
        .ToList();

        if (patient.Count != 0)
        {
            foreach (var p in patient)
            {
                Console.WriteLine($"{p.Id}, {p.Name}, {p.Geburtsdatum}, {p.Versicherungsnummer}");
            }

        }

        else
        {
            Console.WriteLine("Patient nicht gefunden.\n");
        }

    }

    void SucheSozialversicherung(List<Patient> patientenListe)
    {
        Console.WriteLine("Bitte gib die Sozialversicherungsnummer des Patienten an, nach dem du suchen möchtest:\n");
        int versicherungsnummer = Convert.ToInt32(Console.ReadLine());

        List<Patient> patient = patientenListe
       .Where(p => p.Versicherungsnummer.ToString().StartsWith(versicherungsnummer.ToString(), StringComparison.OrdinalIgnoreCase))
       .ToList();

        if (patient.Count != 0)
        {
            foreach (var p in patient)
            {
                Console.WriteLine($"{p.Id}, {p.Name}, {p.Geburtsdatum}, {p.Versicherungsnummer}");
            }

        }

        else
        {
            Console.WriteLine("Patient nicht gefunden.\n");
        }

    }

}

void LoeschePatienten(List<Patient> patientenListe)
{
    Console.WriteLine("Welche ID soll gelöscht werden?\n");
    int id = Convert.ToInt32(Console.ReadLine());

    Patient p = patientenListe.Find(x => x.Id == id);

    if (p != null)
    {
        patientenListe.Remove(p);
    }

    Console.WriteLine($"Patient {p.Name}, mit der ID: {p.Id} wurde erfolgreich gelöscht.\n");
}




