import { Field, Formik, Form } from "formik";
import "./LoginForm.css";

export interface LoginFormValues {
  email: string;
  password: string;
}

interface LoginFormProps {
  onLoginSubmit: (values: LoginFormValues) => Promise<void>;
}

export default function LoginForm({ onLoginSubmit }: LoginFormProps) {
  const initialValues: LoginFormValues = {
    email: "",
    password: "",
  };

  return (
    <div className="form">
      <h3>Login</h3>

      <Formik
        initialValues={initialValues}
        onSubmit={async (values) => {
          await onLoginSubmit(values);
        }}
      >
        {({ isSubmitting }) => (
          <Form>
            <div className="formFill">
              <label htmlFor="email">Email</label>
              <Field
                id="email"
                name="email"
                type="email"
                placeholder="Your Email..."
                autoComplete="username"
                required
              />

              <label htmlFor="password">Password</label>
              <Field
                id="password"
                name="password"
                type="password"
                placeholder="Your Password..."
                autoComplete="current-password"
                required
              />
            </div>

            <button
              className="mainButton loginButton"
              type="submit"
              disabled={isSubmitting}
            >
              {isSubmitting ? "Logging in..." : "Login"}
            </button>
          </Form>
        )}
      </Formik>
    </div>
  );
}
