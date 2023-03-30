public class Fila {
        String[] vetor = new String[10];

        int fim = -1;


        Fila(int value){
            fim=-1;
            vetor = new String[value];
        }
    public boolean add(String value){
        fim++;
        vetor[fim] = value;
    }

    void remove(){
        for(int i = 0; i < fim; i++){
            vetor[i] = vetor[i + 1];
        }
        fim--;
    }

    void list(){
        for(int i = 0; i <= fim; i++){
            System.out.println(vetor[i]);
        }

        private boolean isFull(){
            if(fim == vetor.length-1){
                return true;
            }
            return false;
        }

    }
}
