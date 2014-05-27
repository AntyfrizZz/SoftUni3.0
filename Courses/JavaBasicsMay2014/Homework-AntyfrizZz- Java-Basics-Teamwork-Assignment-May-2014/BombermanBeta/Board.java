import java.awt.BasicStroke;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.Event;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.Image;
import java.awt.Toolkit;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyAdapter;
import java.awt.event.KeyEvent;

import javax.swing.ImageIcon;
import javax.swing.JPanel;
import javax.swing.Timer;

public class Board extends JPanel implements ActionListener {

	private Dimension dimension;
	private final Font smallFont = new Font("Helvetica", Font.BOLD, 14);

	private boolean inGame = false;
	private boolean dying = false;
	private boolean isSpacePressed = false;
	private boolean isKeyPicked = false;
	private boolean isDoorOpen = false;
	private boolean isSpeedBoost = false;
	private boolean isHeartPicked = false;

	private final int blockSize = 60;
	private final int nbrOfBlocks = 17;
	private final int bbmAnimDelay = 2;
	private final int bbmAnimCounts = 4;
	private final int maxGhosts = 12;
	private int bbmSpeed = 4;
	private int timeToExplode = 0;

	private int bbmAnimCount = bbmAnimDelay;
	private int bbmAnimDir = 1;
	private int bbmAnimPos = 0;
	private int nbrOfGhosts = 0;
	private int lifesLeft, score;
	private int[] dx, dy;
	private int[] ghostX, ghostY, ghostDx, ghostDy, ghostSpeed;

	private Image ghost;
	private Image bbm1Up, bbm2Up, bbm3Up;
	private Image bbm1Down, bbm2Down, bbm3Down;
	private Image bbm1Left, bbm2Left, bbm3Left;
	private Image bbm1Right, bbm2Right, bbm3Right;
	private Image bbmLifesLeft;
	private Image wall, brick, bomb, key, openDoor, closedDoor, speedBoost, explosion, heart;
	
	private int bombX = 0;
	private int bombY = 0;
	private int explX = 0;
	private int explY = 0;

	private int bbmX, bbmY, bbmDx, bbmDy;
	private int reqDx, reqDy, viewDx, viewDy;
	private boolean isSetFire = false;

	private final short leveldata[] = { 
			4096, 4096, 4096, 4096, 4096, 4096, 4096, 4096, 4096, 4096, 4096, 4096, 4096, 4096, 4096, 4096, 4096,
			4096, 3,    14,   271,  15,   271,  15,   271,  271,  271,  271,  271,  271,  271,  271,  15,   4096,
			4096, 13,   4096, 271,  4096, 271,  4096, 15,   4096, 7,    4096, 15,   4096, 7,    4096, 271,  4096,
			4096, 271,  271,  271,  11,   2,    14,   271,  11,   0,    14,   271,  11,   0,    14,   271,  4096,
			4096, 7,    4096, 271,  4096, 13,   4096, 7,    4096, 13,   4096, 271,  4096, 5,    4096, 271,  4096,
			4096, 9,    14,   271,  271,  271,  11,   4,    271,  271,  271,  271,  11,   0,    14,   271,  4096,
			4096, 271,  4096, 271,  4096, 15,   4096, 5,    4096, 7,    4096, 271,  4096, 13,   4096, 271,  4096,
			4096, 271,  271,  271,  15,   271,  271,  5,    271,  9,    10,   6,    271,  271,  271,  271,  4096,
			4096, 7,    4096, 7,    4096, 271,  4096, 5,    4096, 271,  4096, 5,    4096, 7,    4096, 271,  4096,
			4096, 9,    10,   8,    14,   271,  11,   8,    14,   271,  11,   8,    10,   8,    10,   14,   4096,
			4096, 4096, 4096, 4096, 4096, 4096, 4096, 4096, 4096, 4096, 4096, 4096, 4096, 4096, 4096, 4096, 4096};

	private final int validSpeeds[] = { 1, 2, 3, 4, 6, 8 };
	private final int maxSpeed = 6;

	private int currentSpeed = 3;
	private short[] screenData;
	private Timer timer;

	public Board() {
		loadImages();
		initVariables();

		addKeyListener(new TAdapter());

		setFocusable(true);

		setBackground(Color.black);
		setDoubleBuffered(true);
	}

	private void initVariables() {

		screenData = new short[nbrOfBlocks * 11];
		dimension = new Dimension(1020, 660);
		ghostX = new int[maxGhosts];
		ghostDx = new int[maxGhosts];
		ghostY = new int[maxGhosts];
		ghostDy = new int[maxGhosts];
		ghostSpeed = new int[maxGhosts];
		dx = new int[4];
		dy = new int[4];

		timer = new Timer(50, this);
		timer.start();
	}

	@Override
	public void addNotify() {
		super.addNotify();

		initGame();
	}

	private void doAnim() {

		bbmAnimCount--;

		if (bbmAnimCount <= 0) {
			bbmAnimCount = bbmAnimDelay;
			bbmAnimPos = bbmAnimPos + bbmAnimDir;

			if (bbmAnimPos == (bbmAnimCounts - 1) || bbmAnimPos == 0) {
				bbmAnimDir = -bbmAnimDir;
			}
		}
	}

	private void playGame(Graphics2D g2d) {

		if (dying) {

			death();

		} else {

			moveBbm();
			drawBbm(g2d);
			moveGhosts(g2d);
			checkMaze();
			timeToExplode ++;
			if (timeToExplode == 80) {
				timeToExplode = 0;
				
			}
		} 
	}

	private void showIntroScreen(Graphics2D g2d) {

		g2d.setColor(new Color(0, 32, 48));
		g2d.fillRect(300, 220, 300, 100);
		g2d.setColor(Color.white);
		g2d.drawRect(300, 220, 300, 100);

		String startScreen = "Press Enter to start.";
		Font small = new Font("Helvetica", Font.BOLD, 20);

		g2d.setColor(Color.white);
		g2d.setFont(small);
		g2d.drawString(startScreen, 350, 275);
	}

	private void drawScore(Graphics2D g2g) {

		int i;
		String s;

		g2g.setFont(smallFont);
		g2g.setColor(new Color(96, 128, 255));
		s = "Score: " + score;
		g2g.drawString(s, 900, 680);

		for (i = 0; i < lifesLeft; i++) {
			g2g.drawImage(bbmLifesLeft, i * 25, 680, this);
		}
	}
	
	private void drawSpeed(Graphics2D g2g) {

		String s;

		g2g.setFont(smallFont);
		g2g.setColor(new Color(96, 128, 255));
		s = "Speed: " + bbmSpeed + " km/h";
		g2g.drawString(s, 1050, 60);

	}
	
	private void drawNbrOfGhosts(Graphics2D g2g) {

		String s;

		g2g.setFont(smallFont);
		g2g.setColor(new Color(96, 128, 255));
		s = "Students: " + nbrOfGhosts;
		g2g.drawString(s, 1050, 80);

	}


	private void checkMaze() {
		
		if (bbmX == 900 && bbmY == 540 && isKeyPicked == true) {
			score += 50;

			if (nbrOfGhosts < maxGhosts) {
				nbrOfGhosts++;
			}

			if (currentSpeed < maxSpeed) {
				currentSpeed++;
			}
			
			isSpacePressed = false;
			
			if (isSpeedBoost == true) {
				bbmSpeed -= 2;
				isSpeedBoost = false;
			}
			
			lifesLeft += 1;

			initLevel();
		}
	}

	private void death() {

		lifesLeft--;

		if (lifesLeft == 0) {
			inGame = false;
		}


		continueLevel();
	}

	private void moveGhosts(Graphics2D g2d) {

		short i;
		int pos;
		int count;

		for (i = 0; i < nbrOfGhosts; i++) {
			if (ghostX[i] % blockSize == 0 && ghostY[i] % blockSize == 0) {
				pos = ghostX[i] / blockSize + nbrOfBlocks
						* (int) (ghostY[i] / blockSize);

				count = 0;

				if ((screenData[pos] & 1) == 0 && ghostDx[i] != 1) {
					dx[count] = -1;
					dy[count] = 0;
					count++;
				}

				if ((screenData[pos] & 2) == 0 && ghostDy[i] != 1) {
					dx[count] = 0;
					dy[count] = -1;
					count++;
				}

				if ((screenData[pos] & 4) == 0 && ghostDx[i] != -1) {
					dx[count] = 1;
					dy[count] = 0;
					count++;
				}

				if ((screenData[pos] & 8) == 0 && ghostDy[i] != -1) {
					dx[count] = 0;
					dy[count] = 1;
					count++;
				}

				if (count == 0) {

					if ((screenData[pos] & 15) == 15) {
						ghostDx[i] = 0;
						ghostDy[i] = 0;
					} else {
						ghostDx[i] = -ghostDx[i];
						ghostDy[i] = -ghostDy[i];
					}

				} else {

					count = (int) (Math.random() * count);

					if (count > 3) {
						count = 3;
					}

					ghostDx[i] = dx[count];
					ghostDy[i] = dy[count];
				}

			}

			ghostX[i] = ghostX[i] + (ghostDx[i] * ghostSpeed[i]);
			ghostY[i] = ghostY[i] + (ghostDy[i] * ghostSpeed[i]);
			drawGhost(g2d, ghostX[i] + 1, ghostY[i] + 1);

			if (bbmX > (ghostX[i] - 12) && bbmX < (ghostX[i] + 12)
					&& bbmY > (ghostY[i] - 12) && bbmY < (ghostY[i] + 12)
					&& inGame) {

				dying = true;
			}
		}
	}

	private void drawGhost(Graphics2D g2d, int x, int y) {

		g2d.drawImage(ghost, x, y, this);
	}

	private void moveBbm() {

		int pos;
		short ch;

		if (reqDx == -bbmDx && reqDy == -bbmDy) {
			bbmDx = reqDx;
			bbmDy = reqDy;
			viewDx = bbmDx;
			viewDy = bbmDy;
		}

		if (bbmX % blockSize == 0 && bbmY % blockSize == 0) {
			pos = bbmX / blockSize + nbrOfBlocks
					* (int) (bbmY / blockSize);
			ch = screenData[pos];


			if (reqDx != 0 || reqDy != 0) {
				if (!((reqDx == -1 && reqDy == 0 && (ch & 1) != 0)
						|| (reqDx == 1 && reqDy == 0 && (ch & 4) != 0)
						|| (reqDx == 0 && reqDy == -1 && (ch & 2) != 0) || (reqDx == 0
						&& reqDy == 1 && (ch & 8) != 0))) {
					bbmDx = reqDx;
					bbmDy = reqDy;
					viewDx = bbmDx;
					viewDy = bbmDy;
				}
			}

			// Check for standstill
			if ((bbmDx == -1 && bbmDy == 0 && (ch & 1) != 0)
					|| (bbmDx == 1 && bbmDy == 0 && (ch & 4) != 0)
					|| (bbmDx == 0 && bbmDy == -1 && (ch & 2) != 0)
					|| (bbmDx == 0 && bbmDy == 1 && (ch & 8) != 0)) {
				bbmDx = 0;
				bbmDy = 0;
			}
		}
		bbmX = bbmX + bbmSpeed * bbmDx;
		bbmY = bbmY + bbmSpeed * bbmDy;
	}

	private void drawBbm(Graphics2D g2d) {

		if (viewDx == -1) {
			drawBbmLeft(g2d);
		} else if (viewDx == 1) {
			drawBbmRight(g2d);
		} else if (viewDy == -1) {
			drawBbmUp(g2d);
		} else {
			drawBbmDown(g2d);
		}
	}

	private void drawWall(Graphics2D g2d) {
		for (int i = 120; i < 960; i+=120) {
			for (int j = 120; j < 600; j+=120) {
				g2d.drawImage(wall, i, j, this);
			}			
		}
		for (int i = 0; i < 1020; i+=60) {
			g2d.drawImage(wall, i, 0, this);		
		}	
		for (int i = 0; i < 1020; i+=60) {
			g2d.drawImage(wall, i, 600, this);		
		}	
		for (int i = 60; i < 600; i+=60) {
			g2d.drawImage(wall, 0, i, this);		
		}	
		for (int i = 60; i < 600; i+=60) {
			g2d.drawImage(wall, 960, i, this);		
		}	
	}
	
	private void drawBrick(Graphics2D g2d){
		for (int i = 0; i < screenData.length; i++) {
			if (screenData[i] >> 8 == 1) {
				if (i > 17 && i < 33) {
					g2d.drawImage(brick, (i - 17) * 60, 60, this);
				} else if (i > 34 && i < 50) {
					g2d.drawImage(brick, (i - 34) * 60, 120, this);
				} else if (i > 51 && i < 67) {
					g2d.drawImage(brick, (i - 51) * 60, 180, this);
				} else if (i > 68 && i < 84) {
					g2d.drawImage(brick, (i - 68) * 60, 240, this);
				} else if (i > 85 && i < 101) {
					g2d.drawImage(brick, (i - 85) * 60, 300, this);
				} else if (i > 102 && i < 118) {
					g2d.drawImage(brick, (i - 102) * 60, 360, this);
				} else if (i > 119 && i < 135) {
					g2d.drawImage(brick, (i - 119) * 60, 420, this);
				} else if (i > 136 && i < 152) {
					g2d.drawImage(brick, (i - 136) * 60, 480, this);
				} else if (i > 153 && i < 169) {
					g2d.drawImage(brick, (i - 153) * 60, 540, this);
				}				
			}
		}		
	}
	
	private void drawKey(Graphics2D g2d){
		g2d.drawImage(key, 900, 60, this);
	}
	
	private void drawHeart(Graphics2D g2d){
		g2d.drawImage(heart, 360, 300, this);
	}
	
	private void drawClosedDoor(Graphics2D g2d){
		g2d.drawImage(closedDoor, 900, 540, this);
	}	
	
	
	private void drawOpenDoor(Graphics2D g2d){
		g2d.drawImage(openDoor, 900, 540, this);
	}
	
	private void drawSpeedBoost(Graphics2D g2d){
		g2d.drawImage(speedBoost, 60, 540, this);
	}
	
	private void drawBbmUp(Graphics2D g2d) {

		switch (bbmAnimPos) {
		case 1:
			g2d.drawImage(bbm1Up, bbmX + 1, bbmY + 1, this);
			break;
		case 2:
			g2d.drawImage(bbm2Up, bbmX + 1, bbmY + 1, this);
			break;
		case 3:
			g2d.drawImage(bbm1Up, bbmX + 1, bbmY + 1, this);
			break;
		default:
			g2d.drawImage(bbm3Up, bbmX + 1, bbmY + 1, this);
			break;
		}
	}

	private void drawBbmDown(Graphics2D g2d) {

		switch (bbmAnimPos) {
		case 1:
			g2d.drawImage(bbm1Down, bbmX + 1, bbmY + 1, this);
			break;
		case 2:
			g2d.drawImage(bbm2Down, bbmX + 1, bbmY + 1, this);
			break;
		case 3:
			g2d.drawImage(bbm1Down, bbmX + 1, bbmY + 1, this);
			break;
		default:
			g2d.drawImage(bbm3Down, bbmX + 1, bbmY + 1, this);
			break;
		}
	}

	private void drawBbmLeft(Graphics2D g2d) {

		switch (bbmAnimPos) {
		case 1:
			g2d.drawImage(bbm1Left, bbmX + 1, bbmY + 1, this);
			break;
		case 2:
			g2d.drawImage(bbm2Left, bbmX + 1, bbmY + 1, this);
			break;
		case 3:
			g2d.drawImage(bbm1Left, bbmX + 1, bbmY + 1, this);
			break;
		default:
			g2d.drawImage(bbm3Left, bbmX + 1, bbmY + 1, this);
			break;
		}
	}

	private void drawBbmRight(Graphics2D g2d) {

		switch (bbmAnimPos) {
		case 1:
			g2d.drawImage(bbm1Right, bbmX + 1, bbmY + 1, this);
			break;
		case 2:
			g2d.drawImage(bbm2Right, bbmX + 1, bbmY + 1, this);
			break;
		case 3:
			g2d.drawImage(bbm1Right, bbmX + 1, bbmY + 1, this);
			break;
		default:
			g2d.drawImage(bbm3Right, bbmX + 1, bbmY + 1, this);
			break;
		}
	}
	

	private void initGame() {

		lifesLeft = 3;
		score = 0;
		initLevel();
		nbrOfGhosts = 3;
		currentSpeed = 3;
	}

	private void initLevel() {

		int i;
		for (i = 0; i < nbrOfBlocks * 11; i++) {
			screenData[i] = leveldata[i];
			isKeyPicked = false;
			isDoorOpen = false;
			isSpeedBoost = false;
			isHeartPicked = false;
		}

		continueLevel();
	}

	private void continueLevel() {

		short i;
		int dx = 1;
		int random;

		for (i = 0; i < nbrOfGhosts; i++) {

			ghostY[i] = 5 * blockSize;
			ghostX[i] = 7 * blockSize;
			ghostDy[i] = 0;
			ghostDx[i] = dx;
			dx = -dx;
			random = (int) (Math.random() * (currentSpeed + 1));

			if (random > currentSpeed) {
				random = currentSpeed;
			}

			ghostSpeed[i] = validSpeeds[random];
		}

		bbmX = 1 * blockSize;
		bbmY = 1 * blockSize;
		bbmDx = 0;
		bbmDy = 0;
		reqDx = 0;
		reqDy = 0;
		viewDx = -1;
		viewDy = 0;
		dying = false;
	}

	private void loadImages() {

		ghost = new ImageIcon("images/ghost.png").getImage();
		bbm1Up = new ImageIcon("images/up1.png").getImage();
		bbm2Up = new ImageIcon("images/up2.png").getImage();
		bbm3Up = new ImageIcon("images/up3.png").getImage();
		bbm1Down = new ImageIcon("images/down1.png").getImage();
		bbm2Down = new ImageIcon("images/down2.png").getImage();
		bbm3Down = new ImageIcon("images/down3.png").getImage();
		bbm1Left = new ImageIcon("images/left1.png").getImage();
		bbm2Left = new ImageIcon("images/left2.png").getImage();
		bbm3Left = new ImageIcon("images/left3.png").getImage();
		bbm1Right = new ImageIcon("images/right1.png").getImage();
		bbm2Right = new ImageIcon("images/right2.png").getImage();
		bbm3Right = new ImageIcon("images/right3.png").getImage();
		bbmLifesLeft = new ImageIcon("images/lifeLeft.png").getImage();
		wall = new ImageIcon("images/wall.png").getImage();
		brick = new ImageIcon("images/brick.png").getImage();
		bomb = new ImageIcon("images/bomb.png").getImage();
		key = new ImageIcon("images/key.png").getImage();
		openDoor = new ImageIcon("images/openDoor.png").getImage();
		closedDoor = new ImageIcon("images/closedDoor.png").getImage();
		speedBoost = new ImageIcon("images/speedBoost.png").getImage();
		heart = new ImageIcon("images/heart.png").getImage();
		explosion = new ImageIcon("images/explosionFinal.gif").getImage();
	}

	@Override
	public void paintComponent(Graphics g) {
		super.paintComponent(g);

		doDrawing(g);
	}
	
	private void dropBomb(Graphics2D gd){
		gd.drawImage(bomb, bombX, bombY, this);
	}
	
	private void drawExpl(Graphics2D g2d) {
		g2d.drawImage(explosion, explX - 60, explY - 60 , this);
	}
	
	
	
	
	private void blowBomb(){
		if (screenData[bombX/60 + bombY/4 + (bombY/30) + 1] != 4096) {	//right != 4096
			screenData[bombX/60 + bombY/4 + (bombY/30)] &= ~4; // remove right border
			screenData[bombX/60 + bombY/4 + (bombY/30) + 1] &= ~257; // remove brick and left border of the brick
			
			if (screenData[bombX/60 + bombY/4 + (bombY/30) + 2] >> 8 == 0) {
				screenData[bombX/60 + bombY/4 + (bombY/30) + 1] &= ~4; // remove right border of the brick if +2 is not brick
				screenData[bombX/60 + bombY/4 + (bombY/30) + 2] &= ~1; // remove left border +2
			}
			if (screenData[bombX/60 + bombY/4 + (bombY/30) - 16] >> 8 == 0) {
				screenData[bombX/60 + bombY/4 + (bombY/30) + 1] &= ~2; // remove top border of the brick if -16 is not brick
				screenData[bombX/60 + bombY/4 + (bombY/30) - 16] &= ~8; // remove bottom border -15
			}
			if (screenData[bombX/60 + bombY/4 + (bombY/30) + 18] >> 8 == 0) {
				screenData[bombX/60 + bombY/4 + (bombY/30) + 1] &= ~8; // remove bottom border of the brick if +18 is not brick
				screenData[bombX/60 + bombY/4 + (bombY/30) + 18] &= ~2; // remove top border +18
			}
		}
		if (screenData[bombX/60 + bombY/4 + (bombY/30) + 17] != 4096) { //bottom != 4096						
			screenData[bombX/60 + bombY/4 + (bombY/30)] &= ~8; // remove bottom border
			screenData[bombX/60 + bombY/4 + (bombY/30) + 17] &= ~258; // remove brick and top border of the brick
			
			if (screenData[bombX/60 + bombY/4 + (bombY/30) + 34] >> 8 == 0) {
				screenData[bombX/60 + bombY/4 + (bombY/30) + 17] &= ~8; // remove bottom border of the brick if +34 is not brick
				screenData[bombX/60 + bombY/4 + (bombY/30) + 34] &= ~2; // remove top border +34
			}
			if (screenData[bombX/60 + bombY/4 + (bombY/30) + 18] >> 8 == 0) {
				screenData[bombX/60 + bombY/4 + (bombY/30) + 17] &= ~4; // remove right border of the brick if +18 is not brick
				screenData[bombX/60 + bombY/4 + (bombY/30) + 18] &= ~1; // remove left border +18
			}
			if (screenData[bombX/60 + bombY/4 + (bombY/30) + 16] >> 8 == 0) {
				screenData[bombX/60 + bombY/4 + (bombY/30) + 17] &= ~1; // remove left border of the brick if +16 is not brick
				screenData[bombX/60 + bombY/4 + (bombY/30) + 16] &= ~4; // remove right border +16
			}
		}
		if (screenData[bombX/60 + bombY/4 + (bombY/30) - 1] != 4096) {	//left != 4096
			screenData[bombX/60 + bombY/4 + (bombY/30)] &= ~1; // remove left border
			screenData[bombX/60 + bombY/4 + (bombY/30) - 1] &= ~260; // remove brick and right border of the brick
			
			if (screenData[bombX/60 + bombY/4 + (bombY/30) - 2] >> 8 == 0) {
				screenData[bombX/60 + bombY/4 + (bombY/30) - 1] &= ~1; // remove left border of the brick if -2 is not brick
				screenData[bombX/60 + bombY/4 + (bombY/30) - 2] &= ~4; // remove right border -2
			}
			if (screenData[bombX/60 + bombY/4 + (bombY/30) - 18] >> 8 == 0) {
				screenData[bombX/60 + bombY/4 + (bombY/30) - 1] &= ~2; // remove top border of the brick if -18 is not brick
				screenData[bombX/60 + bombY/4 + (bombY/30) - 18] &= ~8; // remove bottom border -18
			}
			if (screenData[bombX/60 + bombY/4 + (bombY/30) + 16] >> 8 == 0) {
				screenData[bombX/60 + bombY/4 + (bombY/30) - 1] &= ~8; // remove bottom border of the brick if +16 is not brick
				screenData[bombX/60 + bombY/4 + (bombY/30) + 16] &= ~2; // remove top border +16
			}
		}
		
		if (screenData[bombX/60 + bombY/4 + (bombY/30) - 17] != 4096) {	 //top != 4096
			screenData[bombX/60 + bombY/4 + (bombY/30)] &= ~2; // remove top border
			screenData[bombX/60 + bombY/4 + (bombY/30) - 17] &= ~264; // remove brick and bottom border of the brick
			
			if (screenData[bombX/60 + bombY/4 + (bombY/30) - 34] >> 8 == 0) {
				screenData[bombX/60 + bombY/4 + (bombY/30) - 17] &= ~2; // remove top border of the brick if -34 is not brick
				screenData[bombX/60 + bombY/4 + (bombY/30) - 34] &= ~8; // remove bottom border -34
			}
			if (screenData[bombX/60 + bombY/4 + (bombY/30) - 18] >> 8 == 0) {
				screenData[bombX/60 + bombY/4 + (bombY/30) - 17] &= ~1; // remove left border of the brick if -18 is not brick
				screenData[bombX/60 + bombY/4 + (bombY/30) - 18] &= ~4; // remove right border -18
			}
			if (screenData[bombX/60 + bombY/4 + (bombY/30) - 16] >> 8 == 0) {
				screenData[bombX/60 + bombY/4 + (bombY/30) - 17] &= ~4; // remove right border of the brick if -16 is not brick
				screenData[bombX/60 + bombY/4 + (bombY/30) - 16] &= ~1; // remove left border -16
			}
		}
	}

	private void doDrawing(Graphics g) {

		Graphics2D g2d = (Graphics2D) g;

		g2d.setColor(Color.cyan);
		g2d.fillRect(0, 0, dimension.width, dimension.height);

		drawScore(g2d);
		drawSpeed(g2d);
		drawNbrOfGhosts(g2d);
		drawWall(g2d);
		drawBrick(g2d);
		
		
		if (isSpacePressed) {
			//timeToExplode++;
			if(isSetBomb) {
			dropBomb(g2d);
			}
			if (timeToExplode % 60 == 0 && isSetBomb) {
//				
				blowBomb();	
				isSetBomb = false;
				isSetFire = true;
			}
			
		//	timeToExplode = 0;
			
		}
		if(/*!isSetBomb*/isSetFire) {
			//TODO: remove fire
			drawExpl(g2d);

//			isSetFire = false;
		}
		if (timeToExplode % 79 == 1) {
			isSetFire = false;
		}
		//timeToExplode = 0;
		if (isKeyPicked == false) {
			drawKey(g2d);
		}
		if (isDoorOpen == false) {
			drawClosedDoor(g2d);
		}else {
			drawOpenDoor(g2d);
		}
		if (isSpeedBoost == false) {
			drawSpeedBoost(g2d);
		}
		if (isHeartPicked == false) {
			drawHeart(g2d);
		}

		if (bbmX == 60 && bbmY == 540 && isSpeedBoost == false) {
			isSpeedBoost = true;
			bbmSpeed += 2;
		}

		if (bbmX == 900 && bbmY == 60) {
			isKeyPicked = true;
			isDoorOpen = true;
		}
		if (bbmX == 360 && bbmY == 300 && isHeartPicked == false) {
			isHeartPicked = true;
			lifesLeft +=1;
		}
		doAnim();

		if (inGame) {
			playGame(g2d);
		} else {
			showIntroScreen(g2d);
		}


		Toolkit.getDefaultToolkit().sync();
		g2d.dispose();
	}

	private boolean isSetBomb = false;
	class TAdapter extends KeyAdapter {

		@Override
		public void keyPressed(KeyEvent e) {

			int key = e.getKeyCode();
			
			if (inGame) {
				if (key == KeyEvent.VK_LEFT) {
					reqDx = -1;
					reqDy = 0;
				} else if (key == KeyEvent.VK_RIGHT) {
					reqDx = 1;
					reqDy = 0;
				} else if (key == KeyEvent.VK_UP) {
					reqDx = 0;
					reqDy = -1;
				} else if (key == KeyEvent.VK_DOWN) {
					reqDx = 0;
					reqDy = 1;
				} else if (key == KeyEvent.VK_ESCAPE && timer.isRunning()) {
					inGame = false;
				} else if (key == KeyEvent.VK_PAUSE) {
					if (timer.isRunning()) {
						timer.stop();
					} else {
						timer.start();
					}
				}else if (key == KeyEvent.VK_SPACE) {
					bombX = bbmX;
					bombY = bbmY;
					explX = bombX;
				    explY = bombY;
					isSpacePressed = true;
					isSetBomb = true;
					//timeToExplode++;
				}
			} else {
				if (key == KeyEvent.VK_ENTER) {
					inGame = true;
					initGame();
				}
			}
		}

		@Override
		public void keyReleased(KeyEvent e) {

			int key = e.getKeyCode();

			if (key == Event.LEFT || key == Event.RIGHT || key == Event.UP
					|| key == Event.DOWN) {
				reqDx = 0;
				reqDy = 0;
			}
		}
	}

	@Override
	public void actionPerformed(ActionEvent e) {

		repaint();
	}
}