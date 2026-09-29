import { Field, Formik, Form } from "formik";
import "../Login/LoginForm.css";
import "./CreateUser.css";

/* Defining the data required for creating a new user  */
export interface CreateUserForm {
  firstname: string;
  lastname: string;
  email: string;
  password: string;
  nationality: string;
  status: string;
}
/* Defining the props that the CreateUserForm component receives*/
interface CreateUserFormProps {
  onCreated: (create: CreateUserForm) => void;
}

function CreateUserForm({ onCreated }: CreateUserFormProps) {
  return (
    <div className="form">
      <h3>Create a new User</h3>

      {/* Handles the form values and form submission */}
      <Formik
        initialValues={{
          firstname: "",
          lastname: "",
          email: "",
          password: "",
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
            <label>Password</label>
            <Field
              id="password"
              name="password"
              placeholder="Your Password..."
              type="password"
            />
            <label>Nationality</label>
            <select id="country" name="country">
              <option value="Norwegian">Norwegian</option>
              <option value="Swedish">Swedish</option>
              <option value="Danish">Danish</option>
            </select>
            <label>Reason for usage: </label>
            <select id="status" name="status">
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
