using System;
using System.Collections.Generic;
using System.Text;

namespace Simulacion
{
    class Square
    {
        private int x, y, id, sentido, vel;

        public Square(int x, int y, int id)
        {
            this.x = x;
            this.y = y;
            this.id = id;

            this.vel = 20;
            Random r = new Random();
            this.sentido = r.Next(1, 9);
            this.id = id;
        }

        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }

        public int getid()
        {
            return id;
        }

        public int getSent()
        {
            return sentido;
        }
        public int getVel()
        {
            return vel;
        }

        public Boolean move(int width, int heigh)
        {
            Boolean bol = true;
            switch (sentido)
            {
                //Arriba a la derecha
                case 1:
                    if (x + vel <= width && y - vel >= 0)
                    {
                        x += vel;
                        y -= vel;

                    }
                    else
                    {
                        bol = false;
                    }

                    break;
                //Abajo a la derecha
                case 2:
                    if (x + vel <= width && y + vel <= heigh)
                    {

                        x += vel;
                        y += vel;

                    }
                    else
                    {
                        bol = false;
                    }

                    break;
                //Abajo a la izquierda
                case 3:
                    if (x - vel >= 0 && y + vel <= heigh)
                    {
                        x -= vel;
                        y += vel;
                    }
                    else
                    {
                        bol = false;
                    }

                    break;
                //Arriba a la izquierda
                case 4:

                    if (x - vel >= 0 && y - vel >= 0)
                    {
                        x -= vel;
                        y -= vel;
                    }
                    else
                    {
                        bol = false;
                    }

                    break;
                //Arriba
                case 5:

                    if (y - vel >= 0)
                    {
                        y -= vel;
                    }
                    else
                    {
                        bol = false;
                    }

                    break;
                // Derecha
                case 6:

                    if (x + vel <= width)
                    {
                        x += vel;
                    }
                    else
                    {
                        bol = false;
                    }

                    break;
                // Abajo
                case 7:

                    if (y + vel <= heigh)
                    {
                        y += vel;
                    }
                    else
                    {
                        bol = false;
                    }

                    break;
                //Izquierda
                case 8:
                    if (x - vel >= 0)
                    {
                        x -= vel;
                    }
                    else
                    {
                        bol = false;
                    }

                    break;
                default:
                    break;
            }

            return bol;
        }

        public void setSentido(int width, int heigh)
        {
            switch (sentido)
            {
                case 1:
                    if (x + vel >= width && y > 0)
                    {
                        sentido = 4;
                    }
                    else if (y - vel <= 0 && x < width)
                    {
                        sentido = 2;
                    }
                    else if (y - vel <= 0 && x + vel >= width)
                    {
                        sentido = 3;
                    }

                    break;
                case 2:

                    if (y + vel >= heigh && x + vel < width)
                    {
                        sentido = 1;
                    }
                    else if (y + vel < heigh && x + vel >= width)
                    {
                        sentido = 3;
                    }
                    else if (y + vel >= heigh && x + vel >= width)
                    {
                        sentido = 4;
                    }
                    break;
                case 3:

                    if (x - vel <= 0 && y + vel >= heigh)
                    {
                        sentido = 1;
                    }
                    else if (x - vel <= 0 && y + vel < heigh)
                    {
                        sentido = 2;
                    }
                    else if (x - vel > 0 && y + vel >= heigh)
                    {
                        sentido = 4;
                    }

                    break;
                case 4:

                    if (x - vel <= 0 && y - vel > 0)
                    {
                        sentido = 1;
                    }
                    else if (x - vel <= 0 && y - vel <= 0)
                    {
                        sentido = 2;
                    }
                    else if (x - vel  > 0 && y - vel  <= 0)
                    {
                        sentido = 3;
                    }
                    break;

                case 5:
                    sentido = 7;
                    break;
                case 6:
                    sentido = 8;
                    break;
                case 7:
                    sentido = 5;
                    break;
                case 8:
                    sentido = 6;
                    break;
                default:
                    break;

            }
        }
    }
}
