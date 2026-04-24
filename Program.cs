using MiniPatientenVerwaltung;
using System;

List<Patient> patientenListe = new List<Patient>();
int id = 1;


while (true)
{
    Console.WriteLine("Gib 1 ein, um einen Patienten anzulegen, 2 um alle Patienten anzuzeigen 3 um einen Patienten zu löschen und 4 um zu beenden.");
    string auswahl = Console.ReadLine();


    switch (auswahl)
    {
        case "1":
            LegePatientenAn(patientenListe);
            break;
        case "2":
            if(patientenListe.Count == 0)
            {
                Console.WriteLine("Patientenliste leer - bitte legen Sie einen Patienten an.");
            }
            else
            {
                ZeigePatientenAn(patientenListe);
            }
            break;
        case "3":
            LoeschePatienten(patientenListe);
            break;
        case "4":
            Console.WriteLine("Programm beendet.");
            return;

        default:
            Console.WriteLine("Falscher Wert.");
            break;
    }
}



void LegePatientenAn(List<Patient> patientenListe)
{
   
    Console.Write("Bitte gib den Namen des Patienten an: ");
    string name = Console.ReadLine();

    Console.Write("Bitte gib das Geburtsdatum des Patienten an: ");
    DateTime geburtsdatum = Convert.ToDateTime(Console.ReadLine());

    Console.Write("Bitte gib die Sozialversicherungsnummer des Patienten an: ");
    int versicherungsnummer = Convert.ToInt32(Console.ReadLine());

    Patient patient = new Patient {Id = id++, Name = name, Geburtsdatum = geburtsdatum, Versicherungsnummer = versicherungsnummer };
    patientenListe.Add(patient);

    Console.WriteLine($"Patient {patient.Name} wurde erfolgreich angelegt.");
}

void ZeigePatientenAn(List<Patient> patientenListe)
{
    foreach (Patient patient in patientenListe)
    {
        Console.WriteLine($"ID: {patient.Id} Name: {patient.Name} Geburtsdatum: {patient.Geburtsdatum:dd.MM.yyyy} Sozialversicherungsnummer: {patient.Versicherungsnummer}");
    }
}

void LoeschePatienten(List<Patient> patientenListe)
{
    Console.WriteLine("Welche Id soll gelöscht werden?");
    int id = Convert.ToInt32(Console.ReadLine());

    Patient p = patientenListe.Find(x => x.Id == id);

    if(p != null)
    {
        patientenListe.Remove(p);
    }

    Console.WriteLine($"Patient {p.Name}, mit der ID: {p.Id} wurde erfolgreich gelöscht.");
}