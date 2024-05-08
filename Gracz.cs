using UnityEngine;

public class Gracz : Postacie
{
    void OnTriggerEnter2D(Collider2D kolizja) {
        if (kolizja.gameObject.CompareTag("ObiektyZbieralne")) {
            Przedmioty zderzylySie= kolizja.gameObject.GetComponent<Zbierajki>().przedmioty;
            if (zderzylySie != null)
            {
                print("Nastapila kolizja: " + zderzylySie.nazwaPrzedmiotu);
                switch (zderzylySie.rodzajPrzedmiotu)
                {
                    case Przedmioty.RodzajPrzedmiotu.MONETA:
                        break;
                    case Przedmioty.RodzajPrzedmiotu.ZYCIE:
                        DodajPunktyZycia(zderzylySie.ilosc);
                        break;
                    default:
                        break;
                }
                kolizja.gameObject.SetActive(false);
            }
        }
    }
    public void DodajPunktyZycia(int ilePunktowDodac)
    {
        punktyZycia = punktyZycia + ilePunktowDodac;
        print("Dodano " + ilePunktowDodac +" zycia...");
    }
}
