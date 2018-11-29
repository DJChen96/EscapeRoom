
// =================================	
// Namespaces.
// =================================

using UnityEngine;

// =================================	
// Define namespace.
// =================================



            // =================================	
            // Classes.
            // =================================
            
            public class WandFollow : MonoBehaviour
            {
                // =================================	
                // Nested classes and structures.
                // =================================

                // ...

                // =================================	
                // Variables.
                // =================================

                // ...
                wandController wc;

                public float speed = 8.0f;
                public float distanceFromCamera = 5.0f;

                public bool ignoreTimeScale;

                // =================================	
                // Functions.
                // =================================

                // ...

                void Awake()
                {
                    
                }

                // ...

                void Start()
                {
                    wc = FindObjectOfType<wandController>();
                }

                // ...

                void Update()
                {
                    //Vector3 mousePosition = Input.mousePosition;
                    //mousePosition.z = distanceFromCamera;

                    //Vector3 mouseScreenToWorld = Camera.main.ScreenToWorldPoint(mousePosition);

                    //float deltaTime = !ignoreTimeScale ? Time.deltaTime : Time.unscaledDeltaTime;
                    Vector3 position = Vector3.Lerp(transform.position, wc.transform.position, 1.0f - Mathf.Exp(-speed * Time.deltaTime));

                    transform.position = position;
                }

                // ...

                void LateUpdate()
                {

                }

                // =================================	
                // End functions.
                // =================================

            }

            // =================================	
            // End namespace.

// =================================	
// --END-- //
// =================================
