package com.company;
import java.util.Arrays;
import java.util.Scanner;

public class Main {
    public static void main(String[] args)
    {
        Product products[] = ReadProductsArray();
        PrintProducts(products);
    }

    private static int n = 5;

    public static Product[] ReadProductsArray() {
        Scanner in = new Scanner(System.in);

        Product products[] = new Product[n];
        for (int i = 0; i < n; i++) {
            System.out.print("Name: ");
            String name = in.nextLine();

            System.out.print("Currency: ");
            String currencyName = in.nextLine();

            System.out.print("Exchange rate: ");
            double exRate = in.nextDouble();
            in.nextLine();

            Currency cost = new Currency(currencyName, exRate);

            System.out.print("Price: ");
            double price = in.nextDouble();
            in.nextLine();

            System.out.print("Quantity: ");
            int quantity = in.nextInt();
            in.nextLine();

            System.out.print("Weight: ");
            int weight = in.nextInt();
            in.nextLine();

            System.out.print("Producer: ");
            String producer = in.nextLine();

            products[i] = new Product(name, cost, price, quantity, weight, producer);
        }

        return products;
    }

    public static void PrintProduct(Product product)
    {
        System.out.print("Name: ");
        System.out.print(product.getName());
        System.out.print("Currency: ");
        System.out.print(product.getCost().getName());
        System.out.print("Exchange rate: ");
        System.out.print(product.getCost().getExRate());
        System.out.print("Quantity: ");
        System.out.print(product.getQuantity());
        System.out.print("Weight: ");
        System.out.print(product.getWeight());
        System.out.print("Producer: ");
        System.out.print(product.getProducer());
    }

    public static void PrintProducts(Product products[])
    {
        for (Product p : products) {
            PrintProduct(p);
            System.out.println("");
        }
    }

    public static Product[] GetProductsInfo(Product products[])
    {
        Product min = products[0];
        Product max = products[0];

        for (int i = 0; i < products.length; i++) {
            if (min.getPrice() > products[i].getPrice()) {
                min = products[i];
            }

            if (max.getPrice() < products[i].getPrice()) {
                max = products[i];
            }
        }

        Product result[] = { min, max };
        return result;
    }

    public static Product[] GetProductsByPrice(Product products[])
    {
        for (int i = 1; i < products.length; i++) {
            for (int j = 0; j < products.length - 1; j++) {
                if (products[j].getPrice() < products[j + 1].getPrice()) {
                    Product temp = products[j];
                    products[j] = products[j + 1];
                    products[j + 1] = temp;
                }
            }
        }

        return products;
    }

    public static Product[] GetProductsByCount(Product products[])
    {
        for (int i = 1; i < products.length; i++) {
            for (int j = 0; j < products.length - 1; j++) {
                if (products[j].getQuantity() < products[j + 1].getQuantity()) {
                    Product temp = products[j];
                    products[j] = products[j + 1];
                    products[j + 1] = temp;
                }
            }
        }

        return products;
    }
}
