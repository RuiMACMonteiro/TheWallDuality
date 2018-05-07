/*
************************************************************************************************************* 
*    21179 - Laboratório de Desenvolvimento de Software                                                     *
*    1501903 - Rui Miguel Monteiro                                                                          *
*    Modulo: Controller.cs class - Controller                                                               *
*************************************************************************************************************
*/

using System;
using System.Collections.Generic;
using System.Linq;

using Duality;
using Duality.Components;
using Duality.Components.Physics;
using Duality.Input;
using Duality.Editor;


namespace TheWall
{

    [RequiredComponent(typeof(RigidBody))]
    [RequiredComponent(typeof(Transform))]
    
    public class Controller : Component, ICmpUpdatable, ICmpInitializable, ICmpCollisionListener
    {
        private bool isInit;
        private bool isPause;
        private Model model;
        private Viewer viewer;
        public void OnInit(Component.InitContext context)
        {
            isInit = true;
            isPause = false;
            //Inicializar obj da class Model
            model = new Model();
            viewer = new Viewer();
            model.setTextLabel("Pressione a tecla SPACE para iniciar.", true);
        }

        public void OnCollisionSolve(Component c, CollisionEventArgs e)
        {

        }

        public void OnCollisionBegin(Component sender, CollisionEventArgs args)
        {
           
        }
        public void OnCollisionEnd(Component sender, CollisionEventArgs args)
        {
            model.collisionProcess(args);
        }

        public void OnCollisionSolved(Component sender, CollisionEventArgs args)
        {
           
        }

        void ICmpUpdatable.OnUpdate()
        {
            //Obter da scene o objecto ShipBlock (bloco ativo)
            GameObject theShipObject = Duality.Resources.Scene.Current.FindGameObject("ShipBlock");
            RigidBody body = theShipObject.GetComponent<RigidBody>();
           

            //Transform transformComponent = this.GameObj.GetComponent<Transform>();
            Transform transformComponent = theShipObject.GetComponent<Transform>();
            //position.X = 0; position.Y = 382;

            Vector2 targetMovement = Vector2.Zero;

            //Tecla ESC para sair do jogo
            if (DualityApp.Keyboard[Key.Escape])
            {
                DualityApp.Terminate();
            }

            //Se em Modo Inicial
            if (isInit)
            {
                //Se pressionar tecla SPACE, aplicar impulso e muda estado inical=false 
                if (DualityApp.Keyboard[Key.Space])
                {
                    isInit = false;
                    model.applyForce();
                    model.setTextLabel("", false);
                    

                }
                else
                {
                    return;
                }
                
            }


            //Tecla P para Pausa
            if (DualityApp.Keyboard[Key.P])
            {
                if (!isPause)
                {
                    isPause = true;
                    Time.Freeze();
                }
                else
                {
                    isPause = false;
                    Time.Resume();
                }
            
            }

            //Tecla cursor - Esq ou Dir
            if (DualityApp.Keyboard[Key.Left])
            {
                targetMovement = -Vector2.UnitX;
            }
            else if (DualityApp.Keyboard[Key.Right])
            {
                targetMovement = Vector2.UnitX;

            }

            //Aplicar movimento do Bloco
            model.moveBlock(theShipObject,body,targetMovement);

            //Validar localizacao da Bola
            model.validateBallPosition();

        }

        public void OnShutdown(Component.ShutdownContext context)
        { 
        }

    }
}

