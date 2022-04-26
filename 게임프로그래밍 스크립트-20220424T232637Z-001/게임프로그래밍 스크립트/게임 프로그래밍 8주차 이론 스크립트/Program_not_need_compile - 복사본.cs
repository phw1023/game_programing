using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


public class Card
{
    public int[] cards = new int[52]; // 카드, A,2,3,4,5,6,7,8,9,10,J,Q,K 순서가 4번 반복
    public int[] carduse = new int[52]; // 0이면 카드 사용 X 1이면 사용했다는 뜻으로 사용

    public Card()
    {
       this.Initiate(); // 생성자 사용시 Initiate로 자동 초기화
    }

    public void Initiate() // 게임 초기 덱 초기화 함수
    {
        for (int i =0; i<4; i++)
        {
            for (int j = 0; j < 13; j++)
            {
                cards[(i * 13) + j] = j+1;
                carduse[(i * 13) + j] = 0;
            }
        }
    }

    public int draw()
    {
        Random random = new Random();
        int value;
        int result;

        value = random.Next(52);
        if(carduse[value] == 0)
        {
            result = cards[value];
            carduse[value] = 1;
        }
        else 
        { 
            while (carduse[value] == 1)
            {
                value = random.Next(52);
            }
            result = cards[value];
            carduse[value] = 1;
        }


        return result;


    }

}

public class Player
{
    public int value = 0;
    public string[] card_record = new string[10];
    public int card_quan = 0;

    public Player()
    {
        value = 0;
        card_quan = 0;
    }
   

    public void draw(int val)
    {

        if (val > 10) // J,Q,K의 경우
        {
            value += 10;
                if(val == 11)
                {
                    card_record[card_quan] = "J";
                }
                if (val == 12)
                {
                    card_record[card_quan] = "Q";
                }
                if (val == 13)
                {
                    card_record[card_quan] = "K";
                }

            card_quan++;
        }
        else if (val == 1) // A의 경우
        {
            value += 11;
            card_record[card_quan] = "A";
            card_quan++;
        }
        else
        {
            value += val;
            card_record[card_quan] = Convert.ToString(val);
            card_quan++;
        }



    }

    public virtual void card_view()
    {
        Console.Write("현재 플레이어 카드목록: ");
        for (int i = 0; i < card_quan; i++)
        {
            Console.Write(card_record[i] + " ");
        }
        Console.WriteLine("");
    }

}

public class Dealer : Player
{

    public Dealer()
    {

    }

    public void deal_card_view()
    {
        Console.Write("현재 딜러 카드목록: ");
        Console.Write("? ");
        for (int i = 1; i < card_quan; i++)
        {
            Console.Write(card_record[i] + " ");
        }
        Console.WriteLine("");
    }

    public override void card_view()
    {
        Console.Write("딜러 최종 카드목록: ");
        for (int i = 0; i < card_quan; i++)
        {
            Console.Write(card_record[i] + " ");
        }
        Console.WriteLine("");
    }
}

namespace Blackjack
{

    

    internal class Program
    {
        static void Main(string[] args)
        {
            int win_count = 0;
            int lose_count = 0;

            while (true)
            {
                Card card = new Card();
                Player player = new Player();
                Dealer dealer = new Dealer();

                string choice = "";

                Console.WriteLine("블랙잭 게임을 시작합니다.");
                Console.WriteLine("=============================================");
                Console.WriteLine("");
                

                Console.WriteLine("딜러가 먼저 2장 드로우 합니다");
 
                Console.WriteLine("딜러 드로우중...");
                dealer.draw(card.draw());
                dealer.draw(card.draw());


                Console.WriteLine("플레이어가 2장 드로우합니다");
 
                Console.WriteLine("플레이어 드로우중...");
                player.draw(card.draw());
                player.draw(card.draw());


                dealer.deal_card_view();
   
                player.card_view();


                if (player.value == 21) // 플레이어 블랙잭일 경우
                {
 
                    Console.WriteLine("블랙잭! 플레이어의 승리!");
                    win_count++;
                }
                else // 일반진행
                {
                    while(true)
                    {
  
                        Console.WriteLine("한 장 더 드로우 하시겠습니까? \n 랜덤 결정: ");
                        choice = Console.ReadLine();
                        Random random = new Random();
                        int ran = random.Next(2);

                        if(ran < 1)
                        {
                            choice = "y";
                        }
                        else 
                        {
                            choice = "n";
                        }

                        if(choice == "y" || choice == "Y")
                        {
                            Console.WriteLine("플레이어 드로우");
               
                            player.draw(card.draw());
                         
                            player.card_view();
                    
                            if (player.value > 21) // 드로우 했을시 버스트 검증
                            {
                                Console.WriteLine("버스트! 패배했습니다.");

                                break;
                            }

                            if (player.value == 21) // 드로우 했을시 21이면, 더 드로우 불가
                            {
                                Console.WriteLine("21에 도달했습니다. 드로우를 종료합니다.");

                                break;
                            }

                            if (dealer.value < 17) // 딜러는 17 이하라면 드로우해야함
                            {
                                Console.WriteLine("딜러 드로우");
                                dealer.draw(card.draw());
                                dealer.deal_card_view();
                            }
                        }
                        else if(choice == "n" || choice == "N")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("잘못된 입력 발생, 다시 입력해주세요");
                        }
                    }

                }

                while (dealer.value < 17 && player.value < 22) // 딜러는 17 이하라면 계속해서 드로우해야함
                {
               
                    Console.WriteLine("딜러 드로우");
                    dealer.draw(card.draw());
                    dealer.deal_card_view();
                }



           
                // 승패 검증 파트
                if (player.value ==21 && player.card_quan == 2)
                {

                }
                else if(player.value > 21) // 플레이어 버스트 우선 검증
                {
                    lose_count++;
                }
                else if(dealer.value > 21) // 딜러 버스트 검증
                {
                    Console.WriteLine("드로우 종료. 딜러의 모든 카드를 공개합니다.");
                 
                    dealer.card_view();
                
                    Console.WriteLine("딜러 버스트! 승리했습니다!");
                    win_count++;
                }
                else
                {
                    Console.WriteLine("드로우 종료. 딜러의 모든 카드를 공개합니다.");
                
                    dealer.card_view();
                
                    if (player.value > dealer.value)
                    {
                        Console.WriteLine("승리했습니다!");
                        win_count++;
                    }
                    else if(player.value < dealer.value)
                    {
                        Console.WriteLine("패배했습니다");
                        lose_count++;
                    }
                    else 
                    {
                        Console.WriteLine("무승부!");
                    }
                }
                
                Console.WriteLine("현재 승: " + win_count + " 패: " +lose_count);
                Console.WriteLine("한 판 더 하시겠습니까? \n Y/N 입력으로 결정: ");
                choice = Console.ReadLine();


                choice = "y";


                if (choice == "y" || choice == "Y")
                {
                    Console.WriteLine("");
                    Console.Clear();
                }
                else if (choice == "n" || choice == "N")
                {
                    Console.WriteLine("게임을 종료합니다");
                    
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 입력 발생, 게임을 종료합니다");
                    
                    break;
                }




            }




        }
    }
}
