/*Implemente uma fila de String com as operações básicas de uma fila num vetor de 10 elementos.
 */
public class Main {

    public static void main(String[] args) {
    Fila opFila = new Fila();

    opFila.add("Arthur");
    opFila.add("Joao");
    opFila.add("Claudio");
    opFila.list();
    opFila.remove();
    opFila.list();

    }
}