import { Field, Formik, Form } from "formik";
import "../Login/LoginForm.css";
import "./CreateUser.css";

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
            <Field
              id="firstname"
              name="firstname"
              placeholder="Your First Name..."
              type="text"
            />
            <label>Last Name</label>
            <Field
              id="lastname"
              name="lastname"
              placeholder="Your Last Name..."
              type="text"
            />
            <label>Email</label>
            <Field
              id="email"
              name="email"
              placeholder="Your Email..."
              type="email"
            />
            <label>Nationality</label>
            <select id="country" name="country">
              <option value="Norwegian">Norwegian</option>
              <option value="Swedish">Swedish</option>
              <option value="Danish">Danish</option>
            </select>
            <label>Reason for usage: </label>
            <select id="status" name="staus">
              <option value="Work">Work</option>
              <option value="Hobby">Hobby</option>
              <option value="Study">Study</option>
            </select>
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
