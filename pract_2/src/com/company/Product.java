package com.company;
import java.util.Scanner;

public class Product {

    protected String Name;
    protected Currency Cost;
    protected double Price;
    protected int Quantity;
    protected int Weight;
    protected String Producer;

    Product() { }

    Product(String Name, double Price) {
        this.Name = Name;
        this.Price = Price;
    }

    Product(String Name, Currency Cost, double Price, int Quantity, int Weight, String Producer) {
        this.Name = Name;
        this.Cost = Cost;
        this.Price = Price;
        this.Quantity = Quantity;
        this.Weight = Weight;
        this.Producer = Producer;
    }

    public String getName() {     return Name; }
    public Currency getCost() {   return Cost; }
    public double getPrice() {       return Price; }
    public int getQuantity() {    return Quantity; }
    public int getWeight() {      return Weight; }
    public String getProducer() { return Producer; }

    public void setName(String name) {         Name = name; }
    public void setCost(Currency cost) {       Cost = cost; }
    public void setPrice(double price) {       Price = price; }
    public void setQuantity(int quantity) {    Quantity = quantity; }
    public void setWeight(int weight) {        Weight = weight; }
    public void setProducer(String producer) { Producer = producer; }

    int GetPriceInUAH()
    {
        return (int) (Price * Cost.getExRate());
    }

    int GetTotalPriceInUAH()
    {
        return (int) (Price * Cost.getExRate() * Quantity);
    }

    int GetTotalWeight()
    {
        return Weight * Quantity;
    }
}
