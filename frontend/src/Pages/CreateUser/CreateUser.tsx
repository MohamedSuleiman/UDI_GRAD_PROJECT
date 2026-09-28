import { Field, Formik, Form } from "formik";

export interface CreateUserForm {
  firstname: string;
  lastname: string;
  email: string;
  nationality: string;
  status: string;
}

interface CreateUserFormProps {
  onCreated: (create: CreateUserForm) => void;
}

function CreateUserForm({ onCreated }: CreateUserFormProps) {
  return (
    <div className="form">
      <h3>Create a new User</h3>
      <Formik
        initialValues={{
          firstname: "",
          lastname: "",
          email: "",
          nationality: "",
          status: "",
        }}
        onSubmit={(values) => {
          onCreated(values);
        }}
      >
        <Form>
          <div className="formFill">
            <label>First Name</label>
            <Field id="name" name="name" type="text" />
            <label>Last Name</label>
            <Field id="name" name="name" type="text" />
            <label>Email</label>
            <Field id="email" name="email" type="email" />
            <label>Nationality</label>
            <Field id="nationality" name="nationality" type="text" />
            <label>Staus</label>
            <Field id="status" name="status" type="text" />
          </div>
          <button id="createButton" type="submit">
            Create
          </button>
        </Form>
      </Formik>
    </div>
  );
}
export default CreateUserForm;
