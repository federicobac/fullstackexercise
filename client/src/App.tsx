import { APITester } from "./APITester";
import "./index.css";

import logo from "./logo.svg";
import reactLogo from "./react.svg";
import {useEffect, useState} from "react";
import {Api, MyAmazingEntity} from "@/api/Api.ts";

const api = new Api();

export function App() {
    const [entities, setEntities] = useState<MyAmazingEntity[]>([]);

    useEffect(() => {
        api.api.myAmazingGetEntities()
            .then((data) => {
                setEntities(data);
            })
            .catch((error) => {
                console.error(error);
            });
    }, []);

    const createEntity = () => {
        api.api.myAmazingCreateEntity({
            entityName: "My first entity"
        })
            .then((newEntity) => {
                setEntities([...entities, newEntity]);
            })
            .catch((error) => {
                console.error(error);
            });
    };
    
    const updateEntity = (id: number) => {
        api.api.myAmazingUpdateEntity(
            { id: id },
            { entityName: "Updated entity" }
        )
            .then((updatedEntity) => {
                setEntities((currentEntities) =>
                currentEntities.map((entity) => 
                entity.id === id ? updatedEntity : entity)
            );
            })
        .catch((error) => {
            console.error(error);
        });
    };
    
    return (
      <div>
          <h1>My Amazing Entities</h1>

          <button onClick={createEntity}>
              Create entity
          </button>

          {entities.map((entity) => (
              <div key={entity.id}>
                  {entity.id} - {entity.entityName}
                  
                  <button onClick={() => updateEntity(entity.id!)}>
                      Update entity
                  </button>
              </div>
          ))}
      </div>
    );
}

export default App;
