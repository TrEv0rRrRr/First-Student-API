# Bounded Contexts

## Bus

- Bounded Context: **Assets**
- Auditable, por ende tiene los atributos `createdAt` y `updatedAt`

### Atributos

- `id` (int, Primary Key, Autogenerado)
- `vehiclePlate` (string, Obligatorio, no vacío)
- `fuelTankType` (string, Obligatorio, no vacío)
- `districtId` (int, Obligatorio, no vacío)
- `totalSeats` (int, obligatorio, no vacío)

#### districtId enum

| `districtId` |
| ------------ |
| 1            |
| 2            |
| 3            |

#### fuelTankType enum

| `id` | `fuelTankType` |
| ---- | -------------- |
| 1    | A              |
| 2    | B              |
| 3    | C              |
| 4    | D              |

## Assignment y Student

- Bounded Context: **Operations**

### Assignment

- Auditable, por ende tiene los atributos `createdAt` y `updatedAt`

#### Atributos

- `id` (int, Primary Key, Autogenerado)
- `studentId` (int, Obligatorio)
- `busId` (int, Obligatorio)
- `assignedAt` (datetime, obligatorio)

### Student

- Entity
- No auditable

#### Atributos

- `id` (int, Primary Key, Autogenerado)
- `firstName` (string, Obligatorio, no vacío)
- `lastName` (string, Obligatorio, no vacío),
- `districtId` (int, obligatorio)
- `parentId` (int, Obligatorio)

#### Nota

Indica que la información de Student se debe agregar de forma automática con los datos especificados previamente. Utilizar UseSeeding de Entity Framework Core

| `id` | `firstName` | `lastName` | `districtId` | `parentId` |
| ---- | ----------- | ---------- | ------------ | ---------- |
| 1    | Emma        | Smith      | 1            | 101        |
| 2    | Liam        | Smith      | 1            | 101        |
| 3    | Olivia      | Johnson    | 1            | 102        |
| 4    | Noah        | Johnson    | 1            | 102        |
| 5    | Ava         | Wilson     | 2            | 103        |
| 6    | James       | Wilson     | 2            | 103        |
| 7    | Sophia      | Anderson   | 2            | 104        |
| 8    | William     | Anderson   | 2            | 104        |
| 9    | Isabella    | Jackson    | 3            | 105        |
| 10   | Lucas       | Jackson    | 3            | 105        |

# Business Rules

## Bus

- [ ] No permite que se registre dos buses con el mismo `vehiclePlate`.
- [x] Indica que los valores válidos para `districtId` son 1, 2 o 3.
- [x] Indica que los valores válidos para `fuelTankType` son A, B, C o D.
- [ ] Indica que los valores válidos para `vehiclePlate` son tres caracteres alfabéticos en **mayúsculas**, un guión y cuatro dígitos (por ejemplo, **ABC-1234**).
- [ ] Especifica que los valores válidos para `totalSeats` son números enteros **entre 20 y 40**.
- [ ] Indica que las asignaciones a un bus no deben exceder su `totalSeats`.

## Assignment

- [x] Requiere que el valor de `assignedAt` sea poblado de **forma automática** al momento del registro con la fecha y hora actual.
- [x] No permite que se registre dos assignments con el mismo valor de `studentId`.
- [x] Especifica que los students con el mismo `parentId` **no deben asignarse a vehículos distintos**.

## Relaciones de entidad

- [ ] Especifica que un Bus puede ser referenciado en **uno o muchos** Assignments, pero **un** Assignment solo puede referenciar a **un** Bus en particular.
- [x] Especifica que **un** Assignment puede referenciar a **un** Student, y **un** Student solo puede ser referenciado por **un** Assignment **a la vez**.

# Endpoints

## Buses Endpoint `(/api/v1/buses)`

- Implementar **2 operaciones**, un `POST` para agregar un bus y un `GET` para obtener un bus por su `id`.
- El `ìd` es autogenerado.
- Retornar un `201`
- Para ambas operaciones incluir en la response el `id` autogenerado y los demás atributos, **menos los de auditoría**.

## Assignments Endpoint `(/api/v1/buses/{busId}/assignments)`

- Implementar una operación `POST`
- El valor de `busId` es parte path, por lo tanto **no** debe ser llegar poe el body del request.
- Retornar un `201`
- Incluir en la response el `id` autogenerado y los demás atributos, **menos los de auditoría**.
