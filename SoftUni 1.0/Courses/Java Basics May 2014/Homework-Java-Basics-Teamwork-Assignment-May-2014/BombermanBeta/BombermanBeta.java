import java.awt.EventQueue;
import javax.swing.JFrame;

public class BombermanBeta extends JFrame {

    public BombermanBeta() {
        
        initUI();
    }
    
    private void initUI() {
        
        add(new Board());
        setTitle("BombermanBeta");
        setDefaultCloseOperation(EXIT_ON_CLOSE);
        setSize(1200, 800);
        setLocationRelativeTo(null);
        setVisible(true);        
    }

    public static void main(String[] args) {

        EventQueue.invokeLater(new Runnable() {

            @Override
            public void run() {
                BombermanBeta ex = new BombermanBeta();
                ex.setVisible(true);
            }
        });
    }
}