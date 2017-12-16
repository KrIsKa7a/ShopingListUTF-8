package shoppinglist.bindingModel;

import javax.validation.constraints.NotNull;
import javax.validation.constraints.Size;

public class ProductBindingModel {
	@NotNull
    private int priority;

	@NotNull
    @Size(min = 1)
    private String name;

	@NotNull
    private int quantity;

	@NotNull
    private String status;

    public int getPriority() {
        return priority;
    }

    public void setPriority(int priority) {
        this.priority = priority;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public int getQuantity() {
        return quantity;
    }

    public void setQuantity(int quantity) {
        this.quantity = quantity;
    }

    public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }
}
