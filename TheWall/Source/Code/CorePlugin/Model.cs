/*
************************************************************************************************************* 
*    21179 - Laboratório de Desenvolvimento de Software                                                     *
*    1501903 - Rui Miguel Monteiro                                                                          *
*    Modulo: Model.cs class - Model                                                                         *
*************************************************************************************************************
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Duality;
using Duality.Components;
using Duality.Components.Physics;
using Duality.Input;
using Duality.Editor;
using Duality.Components.Renderers;

namespace TheWall
{
    [RequiredComponent(typeof(RigidBody))]
    [RequiredComponent(typeof(Transform))]

    public class Model
    {
        static Vector2 targetMovement;
        static Vector3 position;

        public Model()
        {
            targetMovement = Vector2.Zero;
            position = new Vector3(0,220,0);
        }

        //Gestor de colisoes
        public void collisionProcess(CollisionEventArgs args)
        {
            RigidBody stats = args.CollideWith.GetComponent<RigidBody>();
            if (stats != null)
            {
                //Do something...
                try
                {
                    //Obter da scene o objecto o BrickBlock ou DefaultBlock
                    GameObject theBlockObject = Duality.Resources.Scene.Current.FindGameObject("DefaultBlock");
                    RigidBody bodyBlock = theBlockObject.GetComponent<RigidBody>(); 
                    if (bodyBlock == stats)
                    {
                        theBlockObject.DisposeLater();
                    }
                }
                catch (Exception e) { }
            }
        }

        //Retorna posicionamento
        public Vector3 getPosition()
        {
            return position;
        }

        
        //Aplicar movimento ao bloco
        public void moveBlock(GameObject Object, RigidBody body, Vector2 targetMovement)
        {
            Transform transformComponent = Object.GetComponent<Transform>();
            if (transformComponent.Pos.X <= 350 && transformComponent.Pos.X >= -350)
            {
                body.ApplyLocalForce(targetMovement * 0.2f * body.Mass);
            }
            else
            {
                transformComponent.Pos = keepInPanel(transformComponent.Pos.X, transformComponent.Pos.Y);
            }
                
        }

        //Verifica se bloco permance dentro do painel
        public Vector3 keepInPanel(float X, float Y)
        {
            position.X = X;
            position.Y = 220;
            if (X <= -350)
            {
                position.X = -350;
            }
            if (X >= 350)
            {
                position.X = 350;
            }
            return position;
        }
        
        //Aplicar ao bloco impulso
        public void applyForce()
        {
            //Obter da scene o objecto Ball
            GameObject theBallObject = Duality.Resources.Scene.Current.FindGameObject("Ball");
            RigidBody bodyBall = theBallObject.GetComponent<RigidBody>();
            if (bodyBall != null)
            {
                targetMovement = -Vector2.UnitY;
                bodyBall.ApplyLocalForce(targetMovement * 0.07f * bodyBall.Inertia);
            }

        }

        public void validateBallPosition()
        {
            //Obter da scene o objecto Ball
            GameObject theBallObject = Duality.Resources.Scene.Current.FindGameObject("Ball");
            RigidBody bodyBall = theBallObject.GetComponent<RigidBody>();
            if (bodyBall != null)
            {
                Transform transformComponent = theBallObject.GetComponent<Transform>();
                if (transformComponent.Pos.Y >= 250)
                {
                    //Afixa mensagem com texto de GameOver
                    //setTextLabel("Game Over.", true);
                    //Time.Freeze();
                    //Time.Resume();
                    DualityApp.Terminate();
                }
            }
        }

        public void setTextLabel(string text, bool state)
        {
            GameObject theTextLabelObject = Duality.Resources.Scene.Current.FindGameObject("TextLabel");
            //theTextLabelObject.DisposeLater();
            try
            {
                TextRenderer textLabel = theTextLabelObject.GetComponent<TextRenderer>();
                if(!(text.Trim()==""))
                {
                    string txt = string.Format(text+"/n ");
                    textLabel.Text.SourceText = txt;
                }

                //Conforme var state, mostra texto no ecran
                if (!state)
                {
                    theTextLabelObject.Active = false;
                }
                else
                {
                    theTextLabelObject.Active = true;
                }
                
            }
            catch (Exception e) { }
        }

    }
}
