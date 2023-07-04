using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlayerInteraction : MonoBehaviour
{
	private PlayerContainer _container;

	private InteractionMediator _interactionMediator;

	public void Initialize(PlayerContainer container)
	{
		_container = container;
		_interactionMediator = new InteractionMediator();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.TryGetComponent<IBuyable>(out var buyable))
			_container.TrySpendCurrency(buyable);

		if (other.TryGetComponent<IDispenser>(out var dispenser))
			_interactionMediator.InteractDispenserWithStorage(dispenser, _container);

		if (other.TryGetComponent<IStorage>(out var storage))
			_interactionMediator.InteractDispenserWithStorage(_container, storage);

		if (other.TryGetComponent<IInteractive>(out var interactive))
			interactive.Interact();
	}
}
