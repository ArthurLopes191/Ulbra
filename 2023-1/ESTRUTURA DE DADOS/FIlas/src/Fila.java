public class Fila {
        String[] vetor ;
        int fim, inicio;

    Fila(int value){
        fim=-1;
        inicio =-1;
        vetor = new String[value];
    }

    public void add(String value){
        fim++;
        vetor[fim] = value;
    }

    void remove(){
        for(int i = 0; i < fim; i++){
            vetor[i] = vetor[i + 1];
        }
        fim--;
    }

    void list() {
        for (int i = 0; i <= fim; i++) {
            System.out.println(vetor[i]);
        }
    }

    public boolean isEmpty(){
        if (inicio == -1 && fim == -1){
            return true;
        }
        return false;
    }
    public boolean isFull() {
        if(fim == vetor.length-1){
            return true;
        }
        return false;
    }
}

