import { Field, Formik, Form } from "formik";
import "../../Pages/Login/LoginForm.css";

/* Data required for creating a new user */
export interface CreateUserForm {
  firstname: string;
  lastname: string;
  email: string;
  password: string;
  nationality: string;
  userUsage: string;
}

/* Props received by the form */
interface CreateUserFormProps {
  onCreated: (values: CreateUserForm) => Promise<void>;
}

function CreateUserForm({ onCreated }: CreateUserFormProps) {
  const initialValues: CreateUserForm = {
    firstname: "",
    lastname: "",
    email: "",
    password: "",
    nationality: "",
    userUsage: "",
  };

  return (
    <div className="form">
      <h3>Create a new User</h3>

      <Formik
        initialValues={initialValues}
        onSubmit={async (values) => {
          await onCreated(values);
        }}
      >
        {({ isSubmitting }) => (
          <Form>
            <div className="formFill">
              <label htmlFor="firstname">First Name</label>
              <Field
                id="firstname"
                name="firstname"
                placeholder="Your First Name..."
                type="text"
                required
              />

              <label htmlFor="lastname">Last Name</label>
              <Field
                id="lastname"
                name="lastname"
                placeholder="Your Last Name..."
                type="text"
                required
              />

              <label htmlFor="email">Email</label>
              <Field
                id="email"
                name="email"
                placeholder="Your Email..."
                type="email"
                required
              />

              <label htmlFor="password">Password</label>
              <Field
                id="password"
                name="password"
                placeholder="Your Password..."
                type="password"
                required
              />

              <label htmlFor="nationality">Nationality</label>
              <Field
                as="select"
                id="nationality"
                name="nationality"
                required
              >
                <option value="">Select nationality</option>
                <option value="Norwegian">Norwegian</option>
                <option value="Swedish">Swedish</option>
                <option value="Danish">Danish</option>
              </Field>

              <label htmlFor="userUsage">Reason for usage</label>
              <Field
                as="select"
                id="userUsage"
                name="userUsage"
                required
              >
                <option value="">Select reason</option>
                <option value="Work">Work</option>
                <option value="Hobby">Hobby</option>
                <option value="Study">Study</option>
              </Field>
            </div>

            <button
              className="mainButton"
              id="createButton"
              type="submit"
              disabled={isSubmitting}
            >
              {isSubmitting ? "Creating..." : "Create"}
            </button>
          </Form>
        )}
      </Formik>
    </div>
  );
}

export default CreateUserForm;