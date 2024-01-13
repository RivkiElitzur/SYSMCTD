import { EntityBaseModel } from "./entity-base.model";

export class CustomerModel extends EntityBaseModel {
  name: string | undefined;
  customerNumber: string | undefined;
}
