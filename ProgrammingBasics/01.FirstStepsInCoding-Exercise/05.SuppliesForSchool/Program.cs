/*Пакет химикали - 5.80 лв.
Пакет маркери - 7.20 лв.
Препарат - 1.20 лв (за литър)*/

int pens = int.Parse(Console.ReadLine());
int markers = int.Parse(Console.ReadLine());
int spray = int.Parse(Console.ReadLine());
double discount = double.Parse(Console.ReadLine()) / 100;

double pensPrice = pens * 5.8;
double markersPrice = markers * 7.2;
double sprayPrice = spray * 1.2;

double totalPrice = pensPrice + markersPrice + sprayPrice;
double discountP = totalPrice * discount;
double discountPrice = totalPrice - discountP;

Console.WriteLine(discountPrice);
